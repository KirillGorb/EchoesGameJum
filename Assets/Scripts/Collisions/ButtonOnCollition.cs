using UnityEngine;
using UnityEngine.Events;

public class ButtonOnCollition : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTriggerStay;
    [SerializeField] private UnityEvent _onTriggerExit;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMove>() || other.GetComponent<BoxCollition>())
            _onTriggerStay?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMove>() || other.GetComponent<BoxCollition>())
            _onTriggerExit?.Invoke();
    }
}