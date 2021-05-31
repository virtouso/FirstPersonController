using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    [SerializeField] private BasicFirstPersonController _fpsController;
    [SerializeField] private Animator _legsAnimator;
    [SerializeField] private Animator _handsAnimator;





    #region Unity Callbacks

    private void Update()
    {
        _legsAnimator.SetFloat("Y", _fpsController.MoveSpeed.x);
        _legsAnimator.SetFloat("X", _fpsController.MoveSpeed.y);
        print(_fpsController.MoveSpeed);
    }
    #endregion


}
