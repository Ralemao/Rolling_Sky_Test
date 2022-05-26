using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private Transform _checkPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.EndTurn();
            GameManager.Instance.AddNewCheckPoint(_checkPoint.position);
        }    
    }
}
