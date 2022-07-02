using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameManager : SingletonPersisten<GameManager>
{
    private int _diamonds;
    public int LevelDiamonds { get { return _diamonds; } }

    private Vector3 _checkPoint;
    public Vector3 CheckPoint { get { return _checkPoint; } }

    //DiamondsChild are diamonds that become gamemanager child while playing the level
    //DiamondsChild are setting when checkpoint get save
    private Transform _diamondsChild;
    public void SetDiamondsChild(Transform value)
    {
        if (_diamondsChild == null)
        {
            value.name = "DiamondsChild";
            _diamondsChild = value;
            _diamondsChild.transform.parent = gameObject.transform;
        }
    }

    //Reset values
    public void ResetValues()
    {
        _diamonds = 0;
        //Reset Player start position
        _checkPoint = new Vector3(0, 1, 1);

        if (_diamondsChild != null)
        {
            Destroy(_diamondsChild.gameObject);
            LevelManager.Instance.LevelStarted = false;
        }
    }

    //Set new checkpoint when death
    public Vector3 SetNewCheckPoint { set { _checkPoint = value; } }

    public void EndTurn()
    {
        AudioBG.Instance.StopAudio();
        PlayerController.Instance.SetDisable = true;
        UIGame.Instance.EndPanel(true);
    }

    public void AddDiamond()
    {
        _diamonds++;
        UIGame.Instance.UpdateDiamonds(_diamonds);
    }
}
