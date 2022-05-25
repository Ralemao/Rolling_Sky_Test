using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Singleton<PlayerMovement>
{
    [Header("Player Movement")]
    [SerializeField]
    private float _moveSpeed;
    private float _xMove;
    private float _yMove;
    [SerializeField]
    private float _zMove;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _waitForTuto;
    private bool _isJump;
    private bool _canMove;

    [Header("Camera")]
    [SerializeField]
    private float _cameraMoveSpeed;
    [SerializeField]
    private Transform _camera;
    private Transform _cameraMain;

    private CharacterController _cController;
    private Joystick _joystick;
    private Vector3 _moveDirection;

    void Start()
    {
        _cController = GetComponent<CharacterController>();
        _cameraMain = Camera.main.transform;
        _joystick = Joystick.Instance;
        StartCoroutine(Tutorial());
    }

    IEnumerator Tutorial()
    {
        yield return new WaitForSeconds(_waitForTuto);
        UIGame.Instance.TurnOffTuto();
        _canMove = true;
    }

    void Update()
    {
        SetCameraPosition();

        if (!_canMove) return;
        
        TouchControl();
        Movement();
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
        float magnitude = Mathf.Clamp01(_moveDirection.magnitude) * _moveSpeed;

        _moveDirection = new Vector3(_xMove, 0, _zMove);
        _moveDirection.Normalize();

        _yMove += Physics.gravity.y * Time.deltaTime;

        Jump();

        Vector3 currentMovement = _moveDirection * magnitude;
        currentMovement.y = _yMove;

        _cController.Move(currentMovement * Time.deltaTime);
    }

    private void Jump()
    {
        if (_cController.isGrounded)
        {
            _yMove = -0.5f;

            if (_isJump)
            {
                _isJump = false;
                _yMove = _jumpForce;
            }
        }
    }

    public void SetJump(bool value)
    {
        _isJump = value;
    }

    public void IsMovable(bool value)
    {
        _canMove = value;
    }
}
