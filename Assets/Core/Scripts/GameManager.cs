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
        if (_lives > 0)
            _lives--;

        if (_lives > 0)
            LevelManager.Instance.ReloadScene();

        if (_lives < 1)
        {
            ResetLevel();
            LevelManager.Instance.LevelMenuScene("Level_Menu");
        }
    }

    public void ResetLevel()
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
