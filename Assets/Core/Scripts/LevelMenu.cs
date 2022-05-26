using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField]
    private int _levelIndex;
    private int _stars;

    [SerializeField]
    private Image[] _starsImage;

    void Start()
    {
        LevelButton();
    }

    private void LevelButton()
    {
        if (_levelIndex <= LevelManager.Instance.GetLevel())
        {
            _stars = PlayerPrefs.GetInt("Level_" + _levelIndex);
            GetComponent<Button>().interactable = true;
            StarsAlpha();
        }
    }

    private void StarsAlpha()
    {
        for (int i = 0; i < _stars; i++)
        {
            _starsImage[i].color = new Color(_starsImage[i].color.r, _starsImage[i].color.g, _starsImage[i].color.b, 1f);
        }
    }
}
