using UnityEngine;
using UnityEngine.Events;

public class TargetCollision : MonoBehaviour
{
    [SerializeField] private UnityEvent _eventCollisionInput;

    [SerializeField] private GameObject _objFon;
    [SerializeField] private GameObject _objState;

    [SerializeField] private float _setDistancy;

    protected Transform _player;

    public virtual void Invoke() => _eventCollisionInput?.Invoke();

    private bool IsCheck(Collider2D collision) => collision.GetComponent<PlayerCheckTriggerAndInput>();

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMove>().transform;
        SetFon(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        ActionFon(true, collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ActionFon(false, collision);
    }

    private void ActionFon(bool set, Collider2D collision)
    {
        if (IsCheck(collision))
            SetFon(set);
    }

    private void SetFon(bool set)
    {
        _objFon.SetActive(set);
        _objState.SetActive(!set);
    }
}