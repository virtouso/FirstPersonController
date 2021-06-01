using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{

    [SerializeField] public string Name;
 //   [SerializeField] public bool Enabled;

    [SerializeField] protected  float _fireRate;


    protected Animator _animator;
    public int _animatorLayerIndex;
    protected BasicFirstPersonController _fpsController;

    protected float _counter;

    public abstract void Fire();

    public abstract void Reload();

    public abstract void Sprint(bool value);


    public void Init(Animator animator, int animatorLayerIndex, BasicFirstPersonController fpsController)
    {
        _animator = animator;
        _animatorLayerIndex = animatorLayerIndex;
        _fpsController = fpsController;

        _fpsController.SpeedChanged += Sprint;

    }


    private void Update()
    {
        _counter += Time.deltaTime;
    }


}
