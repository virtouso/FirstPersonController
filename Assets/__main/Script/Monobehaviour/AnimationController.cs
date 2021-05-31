using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    [SerializeField] private BasicFirstPersonController _fpsController;
    [SerializeField] private Animator _legsAnimator;
    [SerializeField] private Animator _handsAnimator;


    #region Utility
    private void MoveLegs()
    {
        _legsAnimator.SetFloat("Y", _fpsController.MoveSpeed.x);
        _legsAnimator.SetFloat("X", _fpsController.MoveSpeed.y);
        print(_fpsController.MoveSpeed);
    }

    private void ChangeWeapon()
    {


        var success = int.TryParse(Input.inputString,out int result);
        if (success)
        {
            DisableAllLayers();
            _handsAnimator.SetLayerWeight(result,1);
        }
    }


    private void DisableAllLayers()
    {
        for (int i = 0; i < 8; i++)
        {
            _handsAnimator.SetLayerWeight(i,0);
        }
    }


    #endregion


    #region Unity Callbacks

    private void Update()
    {
        MoveLegs();
    }

  

    #endregion


}


public enum HandLayers
{
    BaseLayer=0,
    AK=1,
    BAT=2,
    CHAINSAW=3,
    CROSSBOW=4,
    KNIFE=5,
    MP7=6,
    RIFLE=7,
    UZI=8
}
