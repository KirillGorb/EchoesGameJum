using UnityEngine;
using UnityEngine.Events;

public class ContactWithBullet : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTriggerShootEvent;
    [SerializeField] private TypeBullet _contactTypeBullet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Bullet b) && b.BulletType == _contactTypeBullet)
        {

            b.SpawnEffect();
            Destroy(other.gameObject);
            _onTriggerShootEvent?.Invoke();
        }
    }
}