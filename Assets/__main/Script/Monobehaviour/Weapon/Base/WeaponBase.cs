using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{

    [SerializeField] public string Name;
    [SerializeField] public bool Enabled;

    [SerializeField] protected float _fireRate;


    protected Animator _animator;
    protected int _animatorLayerIndex;
    protected float _counter;

    public abstract void Fire();

    public abstract void Reload();

    public abstract void Sprint();


    public void Init(Animator animator, int animatorLayerIndex)
    {
        _animator = animator;
        _animatorLayerIndex = animatorLayerIndex;
    }


    private void Update()
    {
        _counter += Time.deltaTime;
    }


}
