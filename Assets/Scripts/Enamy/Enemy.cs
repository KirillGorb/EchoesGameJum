using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private ShootEnemy _shoot;
    [SerializeField] private MoveEnemy _move;

    [SerializeField] private bool _isDrop = false;

    private GameObject _dropItem;
    private int _countSpawn;

    private void Start()
    {
        _shoot.SetData(this);
        _move.SetData(GetComponent<Rigidbody2D>(), FindObjectOfType<PlayerMove>().transform);
    }

    public void _Init_(EnemyShootData data, float distancyOfPlayer, int countSpawnDrop, GameObject drop)
    {
        _shoot.SetData(data);
        _move.DistancyMove = distancyOfPlayer;
        _countSpawn = countSpawnDrop;
        _dropItem = drop;
        _isDrop = true;
    }

    private void Update()
    {
        _move.Move(transform);
    }

    public void OnDestroys()
    {
        if (_isDrop)
        {
            for (int i = 0; i < _countSpawn; i++)
                Instantiate(_dropItem, transform.position, Quaternion.identity);

            FindObjectOfType<SpawnerEnemy>().CountDeatEnemy++;
        }
    }
}