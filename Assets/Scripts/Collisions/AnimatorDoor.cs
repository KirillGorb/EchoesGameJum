using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorDoor : MonoBehaviour
{
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void SetState(bool IsOpen) => _anim.SetBool("IsOpen", IsOpen);
}