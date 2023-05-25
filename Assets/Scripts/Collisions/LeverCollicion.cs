using UnityEngine;
using UnityEngine.Events;

public class LeverCollicion : TargetCollision
{
    private bool _isFirst = false;

    [SerializeField] private UnityEvent _secondEventCollisionInput;

    private void Start()
    {
        _secondEventCollisionInput?.Invoke();
    }

    public override void Invoke()
    {
        _isFirst = !_isFirst;

        if (_isFirst)
            base.Invoke();
        else
            _secondEventCollisionInput?.Invoke();
    }
}