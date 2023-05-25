using UnityEngine;
using UnityEngine.Events;

public class TargetCollision : MonoBehaviour
{
    [SerializeField] private UnityEvent _eventCollisionInput;

    [SerializeField] private GameObject _objFon;
    [SerializeField] private GameObject _objState;
    [SerializeField] private float _setDistancy;

    private bool isFon = true;
    protected Transform _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMove>().transform;
        SetNoFon();
    }

    public virtual void Invoke() => _eventCollisionInput?.Invoke();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerCheckTriggerAndInput>())
            SetFon();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerCheckTriggerAndInput>())
            SetNoFon();
    }

    private void SetFon()
    {
        if (isFon) return;
        isFon = true;
        _objFon.SetActive(true);
        _objState.SetActive(false);
    }
    private void SetNoFon()
    {
        if (!isFon) return;
        isFon = false;
        _objFon.SetActive(false);
        _objState.SetActive(true);
    }
}