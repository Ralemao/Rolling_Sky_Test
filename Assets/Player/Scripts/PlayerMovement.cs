using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Singleton<PlayerMovement>
{
    [SerializeField]
    private float _moveSpeed;
    private float _xMove;
    [SerializeField]
    private float _zMove;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _gravity;
    private bool _isJump;
    private bool _isDisable;

    [Header("Camera Atributes")]
    [SerializeField]
    private float _cameraMoveSpeed;
    [SerializeField]
    private Transform _camera;
    private Transform _cameraMain;

    private Rigidbody _rb;
    private Joystick _joystick;
    private Vector3 _moveDirection;

    public Rigidbody GetRB()
    {
        return _rb;
    }

    private void Awake()
    {
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _cameraMain = Camera.main.transform;
        _joystick = Joystick.Instance;
    }

    void Update()
    {
        SetCameraPosition();

        if (_isDisable) return;

        TouchControl();
        Movement();
        Jump();
    }

    private void SetCameraPosition()
    {
        _cameraMain.position = Vector3.Lerp(_cameraMain.position, _camera.position, _cameraMoveSpeed * Time.deltaTime);
        _cameraMain.rotation = Quaternion.Lerp(_cameraMain.rotation, _camera.rotation, _cameraMoveSpeed * Time.deltaTime);
        _cameraMain.localScale = Vector3.Lerp(_cameraMain.localScale, _camera.localScale, _cameraMoveSpeed * Time.deltaTime);
    }

    private void TouchControl()
    {
        if (_joystick.Horizontal >= 0.2f)
            _xMove = _moveSpeed;
        else if (_joystick.Horizontal <= -0.2f)
            _xMove = -_moveSpeed;
        else
            _xMove = 0;
    }

    private void Movement()
    {
        _moveDirection = new Vector3(_xMove, _rb.velocity.y, _zMove);
        _rb.velocity = _moveDirection;
    }

    private void Jump()
    {
        if (_isJump)
        {
            if (PlayerCollider.Instance.GetGrounded())
            {
                _isJump = false;
                _moveDirection.y = _jumpForce;
                _rb.AddRelativeForce(_moveDirection, ForceMode.Impulse);
            }
        }
        else
        {
            if (!PlayerCollider.Instance.GetGrounded())
                _moveDirection.y = _rb.velocity.y - _gravity;
        }
    }

    public void SetJump(bool value)
    {
        _isJump = value;
    }

    public void SetDisable(bool value)
    {
        _isDisable = value;
    }
}
