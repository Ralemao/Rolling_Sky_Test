using UnityEngine;

public class UILevel : MonoBehaviour
{
    void Start()
    {
        AudioBG.Instance.MenuAudio();
    }

    public void Menu()
    {
        LevelManager.Instance.MenuScene();
    }

    public void LevelScene(int value)
    {
        LevelManager.Instance.LevelScene(value);
    }
}
