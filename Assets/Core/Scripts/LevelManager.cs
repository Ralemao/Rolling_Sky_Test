using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    private int _levels;

    public int GetLevel()
    {
        return _levels;
    }

    public void ResetLevels()
    {
        _levels = 0;
        AddLevel();
    }

    void Start()
    {
        if (_levels == 0)
            AddLevel();

        _levels = PlayerPrefs.GetInt("Game_Level_", _levels);
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void MenuLevelScene()
    {
        SceneManager.LoadScene("Menu_Level");
    }

    public void LevelScene(int value)
    {
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
        PlayerPrefs.SetInt("Game_Level_", _levels);
    }

    public void SaveLevel(int currentLevel)
    {
        if (GameManager.Instance.GetLevelStars() > PlayerPrefs.GetInt("Level_" + (currentLevel))) 
            PlayerPrefs.SetInt("Level_" + currentLevel, GameManager.Instance.GetLevelStars());

        GameManager.Instance.EndTurn();
    }
}
