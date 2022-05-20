using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void MenuScene(string value)
    {
        SceneManager.LoadScene(value);
    }

    public void LevelMenuScene(string value)
    {
        SceneManager.LoadScene(value);
    }

    public void LevelScene(int value)
    {
        SceneManager.LoadScene(value);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
