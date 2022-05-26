using UnityEngine;

public class LevelUI : MonoBehaviour
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
