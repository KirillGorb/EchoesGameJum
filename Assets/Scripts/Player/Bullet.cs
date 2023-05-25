using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeLive;
    [SerializeField] private float _damage;

    [SerializeField] private GameObject _bulletEffect;

    public TypeBullet BulletType { get; set; }

    public float SetSpeed {set => _speed = value; }

    public void SpawnEffect() => Instantiate(_bulletEffect, transform.position, Quaternion.identity);

    private void Start()
    {
        Destroy(gameObject, _timeLive);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpawnEffect();
        Destroy(gameObject);
    }
}

public enum TypeBullet
{
    Player,
    Enemy
}