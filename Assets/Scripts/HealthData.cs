using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class HealthData : MonoBehaviour, IHealth
{
    [SerializeField] private UnityEvent Death;

    [SerializeField] private float _startHealth = 10;
    [SerializeField] private float _timeRegeneration = 3;
    [SerializeField] private float _sizeRegen = 0.5f;

    private float _health;
    private bool _isFullHealth = true;

    public float Health => _health;
    public float SizeHealth => _startHealth;

    public void ThisDestroy() => Destroy(gameObject);

    public virtual void Damage(float damage = 1)
    {
        _health -= damage;

        if (_health <= 0)
            Death?.Invoke();

        if (_isFullHealth)
            StartCoroutine(Regeneration());
        _isFullHealth = false;
        Debug.Log(_health);
    }

    public virtual void Regen(float _regen = 1)
    {
        _health += _regen;

        if (_health > _startHealth)
        {
            _health = _startHealth;
            _isFullHealth = true;
        }
    }

    private void Awake()
    {
        _health = _startHealth;
    }

    private IEnumerator Regeneration()
    {
        while (Health <= SizeHealth)
        {
            yield return new WaitForSeconds(_timeRegeneration);
            Regen(_sizeRegen);
        }
    }
}