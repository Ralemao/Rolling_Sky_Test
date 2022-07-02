using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    void Start()
    {
        //Set player to current checkpoint
        transform.position = GameManager.Instance.CheckPoint;
    }

    public bool SetDisable { set { PlayerMovement.Instance.enabled = !value; } }
}
