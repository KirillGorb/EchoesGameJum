using System.Collections;
using UnityEngine;

[System.Serializable]
public class ShootEnemy
{
    [SerializeField] private EnemyShootData _enemyShootData;
    [SerializeField] private TypeBullet _bulletTypeSpawn = TypeBullet.Enemy;

    [SerializeField] private Bullet _bulletEnemy;
    [SerializeField] private Transform _spanwPoint;

    public void SetData(MonoBehaviour monoBehaviour)
    {
        monoBehaviour.StartCoroutine(SpawnBullet(monoBehaviour.transform));
    }

    public void SetData(EnemyShootData data) => _enemyShootData = data;

    private IEnumerator SpawnBullet(Transform transform)
    {
        while (true)
        {
            yield return new WaitForSeconds(_enemyShootData.TimeAttack);
            var bullet = MonoBehaviour.Instantiate(_bulletEnemy, _spanwPoint.position, transform.rotation);

            bullet.SetSpeed = _enemyShootData.SpeedBullet;
            bullet.BulletType = _bulletTypeSpawn;
        }
    }
}

[System.Serializable]
public struct EnemyShootData
{
    public float TimeAttack;
    public float SpeedBullet;

    public EnemyShootData(float bulletEnemy, float timeAttack)
    {
        SpeedBullet = bulletEnemy;
        TimeAttack = timeAttack;
    }
}