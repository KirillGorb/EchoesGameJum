using UnityEngine;

public class PlayerCheckTriggerAndInput : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layer;

    private KeyCode ClickType = KeyCode.E;

    private void Update()
    {
        Action();
    }

    private void Action()
    {
        var resorseItem = Physics2D.OverlapCircle(transform.position, _radius, _layer);
        if (resorseItem && resorseItem.TryGetComponent(out TargetCollision target) && Input.GetKeyDown(ClickType))
            target.Invoke();
    }
}