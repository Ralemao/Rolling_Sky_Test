using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : Singleton<PlayerCollider>
{

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.collider.tag)
        {
            case "Box":
                GameManager.Instance.RemoveLives();
                break;

            case "Hammer":
                GameManager.Instance.RemoveLives();
                break;
        }
    }
}
