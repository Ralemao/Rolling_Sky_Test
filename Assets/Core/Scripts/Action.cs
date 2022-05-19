using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    private enum PlatformsActions { Jump, Fall, Box }
    [SerializeField]
    private PlatformsActions actions;

    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (actions.ToString())
            {
                case "Jump":
                    _anim.SetTrigger("jump");
                    other.GetComponent<PlayerMovement>().SetJump(true);
                    break;

                case "Fall":
                    _anim.SetTrigger("fall");
                    break;

                case "Box":
                    _anim.SetTrigger("boxUp");
                    break;
            }
        }
    }
}
