using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : Singleton<PlayerAnimation>
{
    [SerializeField]
    private float _waitForAnim;
    private bool _isDesapear;

    private Animator _anim;
    private Vector3 _newPosition;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(_isDesapear)
            transform.position = _newPosition;
    }

    public void SetPlayerNewPos(Vector3 value)
    {
        _newPosition = value;
    }

    public void ApearAnim()
    {
        _isDesapear = false;
        _anim.SetTrigger("apear");
        StartCoroutine(EndApearAnim());
    }

    IEnumerator EndApearAnim()
    {
        yield return new WaitForSeconds(_waitForAnim);
        PlayerMovement.Instance.SetDisable(false);
    }

    public void DesapearAnim()
    {
        PlayerMovement.Instance.SetDisable(true);
        _anim.SetTrigger("desapear");
        StartCoroutine(EndDesapearAnim());
    }

    IEnumerator EndDesapearAnim()
    {
        yield return new WaitForSeconds(_waitForAnim);
        _isDesapear = true;
    }
}
