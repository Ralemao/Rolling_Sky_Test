using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    void Start()
    {
        transform.position = GameManager.Instance.GetCheckPoint();
    }

    public void SetDisable(bool value)
    {
        PlayerMovement.Instance.enabled = !value;
        PlayerAnimation.Instance.enabled = !value;
    }
}
