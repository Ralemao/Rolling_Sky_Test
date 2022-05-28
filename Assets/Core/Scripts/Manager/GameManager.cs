using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameManager : SingletonPersisten<GameManager>
{
    private int _stars;

    public int GetLevelStars()
    {
        return _stars;
    }

    private Transform _starsChild;
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

    public void SetStarsChild(Transform value)
    {
        if (_starsChild == null)
        {
            value.name = "StarsChild";
            _starsChild = value;
            _starsChild.transform.parent = gameObject.transform;
        }
    }

    public void ResetValues()
    {
        _stars = 0;
        _checkPoint = new Vector3(0, 0.5f, 0);

        if (_starsChild != null)
        {
            Destroy(_starsChild.gameObject);
            LevelManager.Instance.SetLevelStarted(false);
        }
        //AudioBG.Instance.StopAudio();
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

    public void AddStar()
    {
        _stars++;
        UIGame.Instance.UpdateStars(_stars);
    }
}
