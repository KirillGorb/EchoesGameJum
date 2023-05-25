using UnityEngine;

public class PlayerCheckTriggerAndInput : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layer;

    private TargetCollision _target;

    private void Update()
    {
        var s = Physics2D.OverlapCircle(transform.position, _radius, _layer);
        if (s && s.TryGetComponent(out _target) && Input.GetKeyDown(KeyCode.E))
            _target.Invoke();
    }
}