﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : Singleton<PlayerCollider>
{
    private bool _isGrounded;

    public bool GetGrounded()
    {
        return _isGrounded;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                _isGrounded = true;
                break;

            case "Box":
                //Impact with player
                break;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                _isGrounded = false;
                break;
        }
    }
}
