using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameManager : SingletonPersisten<GameManager>
{
    private int _stars;

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

    public void ResetValues()
    {
        _stars = 0;
        _checkPoint = new Vector3(0, 0.5f, 0);
    }

    public void AddNewCheckPoint(Vector3 value)
    {
        _checkPoint = value;
    }

    public void EndTurn()
    {
        //Stop song
        PlayerController.Instance.SetDisable(true);
        UIGame.Instance.EndPanel(true);
    }

    public void AddStar()
    {
        _stars++;
        UIGame.Instance.UpdateStars(_stars);
    }
}
