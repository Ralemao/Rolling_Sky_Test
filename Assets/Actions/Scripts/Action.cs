using UnityEngine;

public class Action : MonoBehaviour
{
    private enum Actions { Jump, Fall, Box, Teleport, Move, Star }
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
                AudioActtions.Instance.PlayAudioClip(_clip);

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
                    if(this.gameObject.name == "In")
                    {
                        other.GetComponent<PlayerAnimation>().SetPlayerNewPos(_obj.transform.position);
                        other.GetComponent<PlayerAnimation>().DesapearAnim();
                    }
                    else
                    {
                        GetComponent<MeshRenderer>().enabled = true;
                        other.GetComponent<PlayerAnimation>().ApearAnim();
                    }
                    break;

                case "Star":
                    GameManager.Instance.AddStar();
                    this.gameObject.SetActive(false);
                    break;
            }
        }
    }
}
