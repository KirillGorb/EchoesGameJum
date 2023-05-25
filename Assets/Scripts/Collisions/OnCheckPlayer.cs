using UnityEngine;
using UnityEngine.Events;

public class OnCheckPlayer : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTriggerStay;
    [SerializeField] private UnityEvent _onTriggerExit;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMove>())
            _onTriggerStay?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMove>())
            _onTriggerExit?.Invoke();
    }
}