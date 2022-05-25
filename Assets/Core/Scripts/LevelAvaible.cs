using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelAvaible : MonoBehaviour
{
    [SerializeField]
    private int _level;
    private int _stars;
    private bool _allStars;

    [SerializeField]
    private Image[] _starsImage;

    void Start()
    {
        LevelButton();
    }

    private void LevelButton()
    {
        if (_level == LevelManager.Instance.GetLevel())
        {
            _stars = GameManager.Instance.GetLevelStars() - 1;

            if (_stars == 3)
                _allStars = true;
        }

        if (_level <= LevelManager.Instance.GetLevel())
        {
            GetComponent<Button>().interactable = true;
            StarsAlpha();
        }
    }

    private void StarsAlpha()
    {
        for (int i = 0; i <= _stars; i++)
        {
            _starsImage[i].color = new Color(_starsImage[i].color.r, _starsImage[i].color.g, _starsImage[i].color.b, 1f);
        }
    }
}
