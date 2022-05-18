using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Singleton<PlayerMovement>
{
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _zMove;
    private float _yMove;
    [SerializeField]
    private float _jumpForce;
    private float _firstStepOffset;
    private bool _isTouch;

    private Rigidbody _rb;
    private Camera _camera;
    private Vector3 worldCoordinates;

    public Rigidbody GetRB()
    {
        return _rb;
    }

    private void Awake()
    {
        _camera = Camera.main;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!_isTouch)
            RunMovement(_rb.velocity.x);
    }

    private void RunMovement(float x)
    {
        _rb.velocity = new Vector3(x, _rb.velocity.y, _moveSpeed * Time.deltaTime);
    }

    public void TouchMove(Vector2 screenPos, float time)
    {
        Vector3 screenCoordinates = new Vector3(screenPos.x, _rb.velocity.y, _camera.nearClipPlane);
        worldCoordinates = _camera.ScreenToWorldPoint(screenCoordinates);

        RunMovement(worldCoordinates.x);
    }

    public void SetTouch(bool value)
    {
        _isTouch = value;
    }
}
