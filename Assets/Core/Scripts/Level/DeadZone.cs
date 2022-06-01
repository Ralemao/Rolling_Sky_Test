using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAudio.Instance.DeathAudio();
            GameManager.Instance.EndTurn();
        }    
    }
}
