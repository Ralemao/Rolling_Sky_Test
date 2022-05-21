using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameManager : SingletonPersisten<GameManager>
{
    [SerializeField]
    private int _lives;
    private int _stars;

    public int GetLives()
    {
        return _lives;
    }

    public int GetLevelStars()
    {
        return _stars;
    }

    private Vector3 _checkPoint;
    
    public Vector3 GetCheckPoint()
    {
        return _checkPoint;
    }

    public override void Awake()
    {
        base.Awake();

        if (_lives == 3)
            ResetLevelSettings();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void AddNewCheckPoint(Vector3 value)
    {
        _checkPoint = value;
    }

    public void RemoveLives()
    {
        //Stop song
        PlayerController.Instance.SetDisable(true);

        if (_lives > 0)
            _lives--;

        if (_lives > 0)
            //Call reload scene by canvas after death for play again
            LevelManager.Instance.ReloadScene();

        if (_lives < 1)
        {
            ResetLevelSettings();
            LevelManager.Instance.LevelMenuScene("Level_Menu");
        }
    }

    public void ResetLevelSettings()
    {
        _lives = 3;
        _stars = 0;
        _checkPoint = new Vector3(0, 0.5f, 0);
    }

    public void AddStar()
    {
        _stars++;
    }
}
