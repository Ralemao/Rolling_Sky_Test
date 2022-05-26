using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField]
    private int _currentLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(LevelManager.Instance.GetLevel() == _currentLevel)
                LevelManager.Instance.AddLevel();

            LevelManager.Instance.SaveLevel(_currentLevel);
            GameManager.Instance.ResetValues();
        }
    }
}
