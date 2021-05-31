using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFirstPersonController : MonoBehaviour
{
    [SerializeField] private float _walkingSpeed = 7.5f;
    [SerializeField] private float _runningSpeed = 11.5f;
    [SerializeField] private float _jumpSpeed = 8.0f;
    [SerializeField] private float _gravity = 20.0f;
    [SerializeField] private Transform _playerCamera;
    [SerializeField] private float _lookSpeed = 2.0f;
    [SerializeField] private float _lookXLimit = 45.0f;

    [SerializeField] private CharacterController _characterController;
   private Vector3 _moveDirection = Vector3.zero;
    float _rotationX = 0;

    [HideInInspector] private bool _canMove = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
      
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
  


        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = _canMove ? (isRunning ? _runningSpeed : _walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = _canMove ? (isRunning ? _runningSpeed : _walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = _moveDirection.y;
        _moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && _canMove && _characterController.isGrounded)
        {
            _moveDirection.y = _jumpSpeed;
        }
        else
        {
            _moveDirection.y = movementDirectionY;
        }

   
        if (!_characterController.isGrounded)
        {
            _moveDirection.y -= _gravity * Time.deltaTime;
        }

       
        _characterController.Move(_moveDirection * Time.deltaTime);

       
        if (_canMove)
        {
            _rotationX += -Input.GetAxis("Mouse Y") * _lookSpeed;
            _rotationX = Mathf.Clamp(_rotationX, -_lookXLimit, _lookXLimit);
            _playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _lookSpeed, 0);
        }
    }
}
