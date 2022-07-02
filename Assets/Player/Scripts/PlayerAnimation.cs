using System.Collections;
using UnityEngine;

public class PlayerAnimation : Singleton<PlayerAnimation>
{
    [SerializeField]
    private float _waitForAnim;
    private bool _isDesapear;

    private Animator _anim;
    private Vector3 _newPosition;
    public Vector3 PlayerNewPos { set { _newPosition = value; } }

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Teleport action
        if(_isDesapear)
            transform.position = _newPosition;
    }

    #region TeleportAnim
    public void ApearAnim()
    {
        _isDesapear = false;
        _anim.SetTrigger("apear");
        StartCoroutine(EndApearAnim());
    }

    IEnumerator EndApearAnim()
    {
        yield return new WaitForSeconds(_waitForAnim);
        _anim.SetTrigger("idle");
        PlayerMovement.Instance.IsMovable = true;
    }

    public void DesapearAnim()
    {
        PlayerMovement.Instance.IsMovable = false;
        _anim.SetTrigger("desapear");
        StartCoroutine(EndDesapearAnim());
    }

    IEnumerator EndDesapearAnim()
    {
        yield return new WaitForSeconds(_waitForAnim);
        _isDesapear = true;
    }
    #endregion

    public void DeathAnim()
    {
        _anim.SetTrigger("death");
    }
}
