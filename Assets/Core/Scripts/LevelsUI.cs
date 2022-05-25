using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsUI : MonoBehaviour
{
    public void Menu()
    {
        LevelManager.Instance.MenuScene();
    }

    public void LevelScene(int value)
    {
        LevelManager.Instance.LevelScene(value);
    }
}
