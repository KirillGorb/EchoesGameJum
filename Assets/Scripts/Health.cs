using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent Death;

    [SerializeField] private UnityEvent<string> _changeHealth;

    [SerializeField] private float _startHealth = 10;
    [Space(4)]
    [SerializeField] private float _timeRegeneration = 3;
    [SerializeField] private float _sizeRegen = 0.5f;
    [Space(5)]
    [SerializeField] private TypeBullet _bulletTypeDamage;

    public TypeBullet BulletType => _bulletTypeDamage;

    private float _health;

    private void Start()
    {
        _health = _startHealth;
        _changeHealth?.Invoke(_health + "/" + _startHealth);
        StartCoroutine(Regeneration());
    }

    public void ThisDestroy() => Destroy(gameObject);

    public void Damage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
            Death?.Invoke();

        _changeHealth?.Invoke(_health + "/" + _startHealth);
    }

    public void Regen(float _regen)
    {
        _health += _regen;
        if (_health > _startHealth)
            _health = _startHealth;

        _changeHealth?.Invoke(_health+"/"+_startHealth);
    }

    private IEnumerator Regeneration()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeRegeneration);
            Regen(_sizeRegen);
        }
    }
}