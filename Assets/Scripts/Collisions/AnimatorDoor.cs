using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorDoor : MonoBehaviour
{
  [SerializeField]  private string _nameBoolAnim = "IsOpen";

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void SetState(bool setOpen) => _anim.SetBool(_nameBoolAnim, setOpen);
}