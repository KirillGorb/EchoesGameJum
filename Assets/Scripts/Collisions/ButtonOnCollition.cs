using UnityEngine;
using UnityEngine.Events;

public class ButtonOnCollition : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTriggerStay;
    [SerializeField] private UnityEvent _onTriggerExit;

    private bool IsCheck(Collider2D other) => other.GetComponent<PlayerMove>() || other.GetComponent<BoxCollition>();

    private void OnTriggerStay2D(Collider2D other)
    {
        if (IsCheck(other))
            _onTriggerStay?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (IsCheck(other))
            _onTriggerExit?.Invoke();
    }
}