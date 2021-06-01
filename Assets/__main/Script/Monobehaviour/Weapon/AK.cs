using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK : WeaponBase
{
    public override void Fire()
    {
        if (!Input.GetMouseButton(0)) return;
        if (_counter < _fireRate) return;
        if (!_animator.GetCurrentAnimatorStateInfo(_animatorLayerIndex).IsName(AnimatorReferences.Idle)) return;

        _counter = 0;

        _animator.Play(AnimatorReferences.Fire, _animatorLayerIndex);
        //todo play sound
    }

    public override void Reload()
    {
        if (!Input.GetKeyDown(KeyCode.R)) return;
        if (!_animator.GetCurrentAnimatorStateInfo(_animatorLayerIndex).IsName(AnimatorReferences.Idle)) return;
        _animator.Play(AnimatorReferences.Reload, _animatorLayerIndex);
    }

    public override void Sprint(bool value)
    {
        if (value)
            _animator.Play(AnimatorReferences.SprintIn, _animatorLayerIndex);
        else
            _animator.Play(AnimatorReferences.SprintOut, _animatorLayerIndex);

    }
}
