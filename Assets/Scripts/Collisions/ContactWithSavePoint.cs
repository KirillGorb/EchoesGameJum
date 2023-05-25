using UnityEngine;
using UnityEngine.Events;

public class ContactWithSavePoint : MonoBehaviour
{
    [SerializeField] private UnityEvent<Vector3> _onTriggerVector3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMove>())
            _onTriggerVector3?.Invoke(transform.position);
    }
}