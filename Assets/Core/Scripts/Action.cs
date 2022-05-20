using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    private enum PlatformsActions { Jump, Fall, Box, Teleport }
    [SerializeField]
    private PlatformsActions _actions;

    [SerializeField]
    private Transform _obj;
    private Animator _anim;

    void Start()
    {
        if(_anim != null)
            _anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (_actions.ToString())
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

                case "Teleport":
                    if(_obj != null)
                        other.GetComponent<PlayerAnimation>().SetPlayerNewPos(_obj.transform.position);

                    other.GetComponent<PlayerAnimation>().DesapearAnim();
                    break;
            }
        }
    }
}
