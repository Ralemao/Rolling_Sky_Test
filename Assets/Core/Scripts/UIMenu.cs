using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : Singleton<UIMenu>
{
    public void LoadMenuLevel()
    {
        LevelManager.Instance.MenuLevelScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Erase()
    {
        PlayerPrefs.DeleteAll();
        LevelManager.Instance.ResetLevels();
    }
}
