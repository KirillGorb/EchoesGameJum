using UnityEngine;

public class PlayerCheckTriggerAndInput : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layer;

    private TargetCollision _target;

    private void Update()
    {
        var resorseItem = Physics2D.OverlapCircle(transform.position, _radius, _layer);
        if (resorseItem && resorseItem.TryGetComponent(out _target) && Input.GetKeyDown(KeyCode.E))
            _target.Invoke();
    }
}