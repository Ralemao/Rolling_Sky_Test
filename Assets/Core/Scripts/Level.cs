using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : SingletonPersisten<Level>
{
    [SerializeField]
    private GameObject[] _levelStarsActive;

    void Start()
    {
        GetAllStars();
    }

    private void GetAllStars()
    {
        _levelStarsActive = GameObject.FindGameObjectsWithTag("Star");

        for (int i = 0; i < _levelStarsActive.Length; i++)
        {
            if (_levelStarsActive[i].name == "null")
                _levelStarsActive[i].SetActive(false);
        }
    }

    public void DeActivateStar(GameObject star)
    {
        for (int i = 0; i < _levelStarsActive.Length; i++)
        {
            if (_levelStarsActive[i].name == star.name)
            {
                _levelStarsActive[i].name = "null";
                _levelStarsActive[i].SetActive(false);
            }  
        }
    }

    public void SetEndLevel()
    {
        Destroy(this.gameObject);
    } 
}
