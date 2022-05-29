using UnityEngine;

public class PlayerCollider : Singleton<PlayerCollider>
{

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.collider.tag)
        {
            case "Box":
                Death();
                break;
        }
    }

    private void Death()
    {
        PlayerAudio.Instance.DeathAudio();
        GameManager.Instance.EndTurn();
    }
}
