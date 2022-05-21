using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    private void Start()
    {
        transform.position = GameManager.Instance.GetCheckPoint();
    }

    public void SetDisable(bool value)
    {
        PlayerMovement.Instance.enabled = !value;
        PlayerAnimation.Instance.enabled = !value;
    }
}
