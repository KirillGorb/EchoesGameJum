using UnityEngine;
using UnityEngine.Events;

public class DoorControler : MonoBehaviour
{
    [SerializeField] private UnityEvent _open;
    [SerializeField] private UnityEvent _close;

    [SerializeField] private bool _isSetOpen = false;

    private bool _isBox;

    public bool IsOpen { get; set; }

    private void Start()
    {
        if (_isSetOpen) OpenDoor();
        else CloseDoor();
    }

    public void OpenDoor()
    {
        if (IsOpen) return;

        IsOpen = true;
        _open?.Invoke();
    }

    public void CloseDoor()
    {
        IsOpen = false;
        if (_isBox) return;

        _close?.Invoke();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<BoxCollition>() && IsOpen)
            _isBox = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<BoxCollition>())
        {
            _isBox = false;
            if (!IsOpen)
                CloseDoor();
        }
    }
}