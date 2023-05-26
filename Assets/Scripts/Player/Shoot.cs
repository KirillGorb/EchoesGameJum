using UnityEngine;
using UnityEngine.Events;

public class Shoot : MonoBehaviour
{
    [SerializeField] private UnityEvent<string> _checkCountBullet;

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Bullet _bullet;

    [SerializeField] private Transform _gun;
    [SerializeField] private Transform _gunShoot;
    [SerializeField] private float _offsetZGunShoot;

    [SerializeField] private TypeBullet _bulletTypeSpawn;

    [SerializeField] private int _countBullet = 0;

    private string ChangeText => _countBullet + "";

    private void Start()
    {
        _checkCountBullet?.Invoke(ChangeText);
        if (_countBullet <= 0)
            _gunShoot.gameObject.SetActive(false);
    }

    public void Update()
    {
        Rotation();
        ShootOnClick();
    }

    private void Rotation()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _gun.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        _gun.rotation = Quaternion.Euler(0, 0, rotateZ);
        _gunShoot.rotation = Quaternion.Euler(0, 0, rotateZ + _offsetZGunShoot);
    }

    private void ShootOnClick()
    {
        if (Input.GetMouseButtonDown(0) && _countBullet > 0)
        {
            _countBullet--;
            Instantiate(_bullet, _spawnPoint.position, _gunShoot.rotation).BulletType = _bulletTypeSpawn;
            _checkCountBullet?.Invoke(ChangeText);

            if (_countBullet <= 0)
                _gunShoot.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            _countBullet++;
            _checkCountBullet?.Invoke(ChangeText);

            Destroy(other.gameObject);
            _gunShoot.gameObject.SetActive(true);
        }
    }
}