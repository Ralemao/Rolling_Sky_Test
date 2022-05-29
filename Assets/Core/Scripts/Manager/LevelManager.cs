using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    private int _levels;
    private bool _isLevelStarted;

    public int GetLevel()
    {
        return _levels;
    }

    public bool GetLevelStarted()
    {
        return _isLevelStarted;
    }

    void Start()
    {
        _levels = PlayerPrefs.GetInt("Game_Level_", _levels);

        if (_levels == 0)
            AddLevel();
    }

    public void SetLevelStarted(bool value)
    {
        _isLevelStarted = value;
    }

    public void MenuScene()
    {
        GameManager.Instance.ResetValues();
        SceneManager.LoadScene("Menu");
    }

    public void MenuLevelScene()
    {
        GameManager.Instance.ResetValues();
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
        if (GameManager.Instance.GetLevelDiamonds() > PlayerPrefs.GetInt("Level_" + (currentLevel))) 
            PlayerPrefs.SetInt("Level_" + currentLevel, GameManager.Instance.GetLevelDiamonds());

        GameManager.Instance.EndTurn();
    }

    public void ResetLevels()
    {
        _levels = 0;
        AddLevel();
    }
}
