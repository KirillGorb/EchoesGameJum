using UnityEngine;
using UnityEngine.Events;

public class Shoot : MonoBehaviour
{
    [SerializeField] private UnityEvent<string> _puckUpBullet;

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Bullet _bullet;

    [SerializeField] private Transform _gun;
    [SerializeField] private Transform _gunShoot;
    [SerializeField] private float _offsetZGunShoot;

    [SerializeField] private TypeBullet _bulletTypeSpawn;

    [SerializeField] private int _countBullet = 0;

    private void Start()
    {
        _puckUpBullet?.Invoke(_countBullet + "");
        if (_countBullet <= 0)
            _gunShoot.gameObject.SetActive(false);
    }

    public void Update()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _gun.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        _gun.rotation = Quaternion.Euler(0, 0, rotateZ);
        _gunShoot.rotation = Quaternion.Euler(0, 0, rotateZ + _offsetZGunShoot);

        if (Input.GetMouseButtonDown(0) && _countBullet > 0)
        {
            _countBullet--;
            Instantiate(_bullet, _spawnPoint.position, _gunShoot.rotation).BulletType = _bulletTypeSpawn;
            _puckUpBullet?.Invoke(_countBullet + "");

            if (_countBullet <= 0)
                _gunShoot.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            _countBullet++;
            Destroy(other.gameObject);
            _puckUpBullet?.Invoke(_countBullet + "");


            _gunShoot.gameObject.SetActive(true);
        }
    }
}