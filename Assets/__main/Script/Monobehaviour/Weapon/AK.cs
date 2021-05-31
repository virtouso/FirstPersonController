using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK : WeaponBase
{
    public override void Fire()
    {
        if (!Input.GetMouseButton(0)) return;
        if (_counter < _fireRate) return;
    //    if(!_animator.GetCurrentAnimatorStateInfo(_animatorLayerIndex).IsName())


    }

    public override void Reload()
    {
    }

    public override void Sprint()
    {
    }
}
