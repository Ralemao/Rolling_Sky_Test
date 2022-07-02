using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private Transform _point;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetNewCheckPoint = _point.position;
        }
    }
}
