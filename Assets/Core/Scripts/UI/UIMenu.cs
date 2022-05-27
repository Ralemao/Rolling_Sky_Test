using UnityEngine;

public class UIMenu : Singleton<UIMenu>
{
    void Start()
    {
        AudioBG.Instance.MenuAudio();
    }

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
