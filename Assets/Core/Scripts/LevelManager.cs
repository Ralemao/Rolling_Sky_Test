using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    private int _levels;

    public int GetLevel()
    {
        return _levels;
    }

    private Level _level;

    void Start()
    {
        _level = FindObjectOfType<Level>();

        if (_levels == 0)
            _levels = 1;
    }

    public void MenuScene()
    {
        if (_level != null)
            FindObjectOfType<Level>().SetEndLevel();

        SceneManager.LoadScene("Menu");
    }

    public void MenuLevelScene()
    {
        SceneManager.LoadScene("Menu_Level");
    }

    public void LevelScene(int value)
    {
        if (_level != null)
            FindObjectOfType<Level>().SetEndLevel();

        GameManager.Instance.ResetValues();
        SceneManager.LoadScene("Level_" + value);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddLevel()
    {
        _levels++;
    }
}
