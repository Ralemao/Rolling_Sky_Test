using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : Singleton<PlayerCollider>
{
    private bool _isGrounded;

    public bool GetGrounded()
    {
        return _isGrounded;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Out")
        {
            other.GetComponent<MeshRenderer>().enabled = true;
            PlayerAnimation.Instance.ApearAnim();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                _isGrounded = true;
                break;

            case "Box":
                PlayerMovement.Instance.SetDisable(true);
                break;

            case "Hammer":
                PlayerMovement.Instance.SetDisable(true);
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
