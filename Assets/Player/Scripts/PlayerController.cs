using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    private void Start()
    {
        transform.position = GameManager.Instance.GetCheckPoint();
    }
}
