using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    private enum Actions { Jump, Fall, Box, Teleport, Move, Star }
    [SerializeField]
    private Actions _actions;

    [SerializeField]
    private Transform _obj;
    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
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

                case "Move":
                    _anim.SetTrigger("move");
                    break;

                case "Teleport":
                    if(_obj != null)
                        other.GetComponent<PlayerAnimation>().SetPlayerNewPos(_obj.transform.position);

                    other.GetComponent<PlayerAnimation>().DesapearAnim();
                    break;

                case "Star":
                    GameManager.Instance.AddStar();
                    Destroy(this.gameObject);
                    break;
            }
        }
    }
}