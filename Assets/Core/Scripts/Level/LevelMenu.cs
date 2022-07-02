using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField]
    private int _levelIndex;
    private int _diamonds;

    [SerializeField]
    private Image[] _diamondsImage;

    void Start()
    {
        LevelButton();
    }

    private void LevelButton()
    {
        if (_levelIndex <= LevelManager.Instance.Levels)
        {
            _diamonds = PlayerPrefs.GetInt("Level_" + _levelIndex);
            GetComponent<Button>().interactable = true;
            DiamondsAlpha();
        }
    }

    private void DiamondsAlpha()
    {
        for (int i = 0; i < _diamonds; i++)
        {
            _diamondsImage[i].color = new Color(_diamondsImage[i].color.r, _diamondsImage[i].color.g, _diamondsImage[i].color.b, 1f);
        }
    }
}
