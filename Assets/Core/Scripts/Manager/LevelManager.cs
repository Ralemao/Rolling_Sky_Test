using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    private int _levels;
    public int Levels { get { return _levels; } }
    private bool _isLevelStarted;
    public bool LevelStarted { get { return _isLevelStarted; } set { _isLevelStarted = value; } }

    void Start()
    {
        _levels = PlayerPrefs.GetInt("Game_Level_", _levels);

        //Set first level avaible
        if (_levels == 0)
            AddLevel();
    }

    public void AddLevel()
    {
        _levels++;
        PlayerPrefs.SetInt("Game_Level_", _levels);
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

    public void SaveLevel(int currentLevel)
    {
        //If currentLevel gets 3 diamonds, then it wont be able to get less if play again
        if (GameManager.Instance.LevelDiamonds > PlayerPrefs.GetInt("Level_" + (currentLevel))) 
            PlayerPrefs.SetInt("Level_" + currentLevel, GameManager.Instance.LevelDiamonds);

        GameManager.Instance.EndTurn();
    }

    public void ResetLevels()
    {
        _levels = 0;
        AddLevel();
    }
}
