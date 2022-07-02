using UnityEngine;

public class Action : MonoBehaviour
{
    private enum Actions { Jump, Fall, Box, Teleport, Move, Diamond }
    [SerializeField]
    private Actions _actions;

    [SerializeField]
    private Transform _obj;
    private Animator _anim;
    [SerializeField]
    private AudioClip _clip;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_clip != null)
                AudioActtions.Instance.PlayAudioClip = _clip;

            switch (_actions)
            {
                case Actions.Jump:
                    _anim.SetTrigger("jump");
                    other.GetComponent<PlayerMovement>().IsJump = true;
                    break;

                case Actions.Fall:
                    _anim.SetTrigger("fall");
                    break;

                case Actions.Box:
                    _anim.SetTrigger("boxUp");
                    break;

                case Actions.Move:
                    _anim.SetTrigger("move");
                    break;

                case Actions.Teleport:
                    if(this.gameObject.name == "In")
                    {
                        other.GetComponent<PlayerAnimation>().PlayerNewPos = _obj.transform.position;
                        other.GetComponent<PlayerAnimation>().DesapearAnim();
                    }
                    else
                    {
                        GetComponent<MeshRenderer>().enabled = true;
                        other.GetComponent<PlayerAnimation>().ApearAnim();
                    }
                    break;

                case Actions.Diamond:
                    GameManager.Instance.AddDiamond();
                    this.gameObject.SetActive(false);
                    break;
            }
        }
    }
}
