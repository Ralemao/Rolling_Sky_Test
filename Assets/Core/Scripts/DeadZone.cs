using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private Transform _checkPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Stop song
            GameManager.Instance.RemoveLives();

            if (GameManager.Instance.GetLives() > 0)
                GameManager.Instance.AddNewCheckPoint(_checkPoint.position);
        }    
    }
}
