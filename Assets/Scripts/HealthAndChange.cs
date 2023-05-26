using UnityEngine;
using UnityEngine.Events;

public class HealthAndChange : HealthData, IHealth
{
    [SerializeField] private UnityEvent<string> _changeHealth;

    public override void Damage(float damage = 1)
    {
        base.Damage(damage);
        _changeHealth?.Invoke(Health + "/" + SizeHealth);
    }

    public override void Regen(float regen = 1)
    {
        base.Regen(regen);
        _changeHealth?.Invoke(Health + "/" + SizeHealth);
    }

    private void Start()
    {
        _changeHealth?.Invoke(Health + "/" + SizeHealth);
    }
}