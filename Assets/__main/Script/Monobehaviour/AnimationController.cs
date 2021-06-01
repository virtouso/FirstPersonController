using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    [SerializeField] private BasicFirstPersonController _fpsController;
    [SerializeField] private Animator _legsAnimator;
    [SerializeField] private Animator _handsAnimator;
    [SerializeField] private Transform _rightHand;
    [SerializeField] private Transform _leftHand;

    private WeaponBase[] _weapons;
    private WeaponBase _currentWeapon;

    #region Utility


    private void InitWeapons()
    {
        _weapons = GetComponents<WeaponBase>();
        foreach (var item in _weapons)
        {
            var myEnum = Enum.Parse(typeof(HandLayers), item.Name);
            item.Init(_handsAnimator, (int)myEnum, _fpsController);
        }
    }

    private void MoveLegs()
    {
        _legsAnimator.SetFloat("Y", _fpsController.MoveSpeed.x);
        _legsAnimator.SetFloat("X", _fpsController.MoveSpeed.y);
        print(_fpsController.MoveSpeed);
    }

    private void ChangeWeapon()
    {


        var success = int.TryParse(Input.inputString.Replace("Alpha", ""), out int result);
        if (success)
        {
            if (_currentWeapon != null)
            {

                _handsAnimator.Play(AnimatorReferences.PutDown, _currentWeapon._animatorLayerIndex);
            }

            StartCoroutine(ChangeToNewWeapon(result));

        }
    }


    IEnumerator ChangeToNewWeapon(int result)
    {

        yield return new WaitForSeconds(1);
        DisableAllLayers();
        DisableAllWeaponsObject();
        _handsAnimator.SetLayerWeight(result, 1);
        _currentWeapon = _weapons.First(x => x._animatorLayerIndex == result);
        _currentWeapon.WeaponObject.SetActive(true);
        _rightHand.localPosition = _currentWeapon.RightHandOffset;
        _leftHand.localPosition = _currentWeapon.LeftHandOffset;
        _handsAnimator.Play(AnimatorReferences.Take, _currentWeapon._animatorLayerIndex);
    }


    private void DisableAllLayers()
    {
        for (int i = 0; i < 9; i++)
        {
            _handsAnimator.SetLayerWeight(i, 0);
        }
    }

    private void DisableAllWeaponsObject()
    {
        foreach (var item in _weapons)
        {
            if (item.WeaponObject == null) continue;
            item.WeaponObject.SetActive(false);
        }
    }
    private void HandleCurrentWeapon()
    {
        if (_currentWeapon is null) return;
        _currentWeapon.Reload();
        _currentWeapon.Fire();

    }


    #endregion


    #region Unity Callbacks

    private void Start()
    {
        InitWeapons();
    }


    private void Update()
    {
        ChangeWeapon();
        MoveLegs();
        HandleCurrentWeapon();
    }



    #endregion


}


public enum HandLayers
{
    BaseLayer = 0,
    AK = 1,
    BAT = 2,
    CHAINSAW = 3,
    CROSSBOW = 4,
    KNIFE = 5,
    MP7 = 6,
    RIFLE = 7,
    UZI = 8
}
