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

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMove>().transform;
        SetFon(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerCheckTriggerAndInput>())
            SetFon(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerCheckTriggerAndInput>())
            SetFon(false);
    }

    private void SetFon(bool set)
    {
        _objFon.SetActive(set);
        _objState.SetActive(!set);
    }
}