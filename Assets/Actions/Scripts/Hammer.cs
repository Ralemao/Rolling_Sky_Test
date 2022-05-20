using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    private enum RotationDegrees { rot180, rot360 }
    [SerializeField]
    private RotationDegrees _degrees;

    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _anim.SetTrigger(_degrees.ToString());
    }
}
