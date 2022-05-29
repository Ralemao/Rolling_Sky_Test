using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameManager : SingletonPersisten<GameManager>
{
    private int _diamonds;

    public int GetLevelDiamonds()
    {
        return _diamonds;
    }

    private Transform _diamondsChild;
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
        //Debug.Log(LevelManager.Instance.GetLevel());
    }

    public void SetDiamondsChild(Transform value)
    {
        if (_diamondsChild == null)
        {
            value.name = "DiamondsChild";
            _diamondsChild = value;
            _diamondsChild.transform.parent = gameObject.transform;
        }
    }

    public void ResetValues()
    {
        _diamonds = 0;
        _checkPoint = new Vector3(0, 0.5f, 0);

        if (_diamondsChild != null)
        {
            Destroy(_diamondsChild.gameObject);
            LevelManager.Instance.SetLevelStarted(false);
        }
    }

    public void AddNewCheckPoint(Vector3 value)
    {
        _checkPoint = value;
    }

    public void EndTurn()
    {
        AudioBG.Instance.StopAudio();
        PlayerController.Instance.SetDisable(true);
        UIGame.Instance.EndPanel(true);
    }

    public void AddDiamond()
    {
        _diamonds++;
        UIGame.Instance.UpdateDiamonds(_diamonds);
    }
}
