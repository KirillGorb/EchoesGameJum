using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private ShootEnemy _shoot;
    [SerializeField] private MoveEnemy _move;

    private void Start()
    {
        _shoot.SetData(this);
        _move.SetData(GetComponent<Rigidbody2D>(), FindObjectOfType<PlayerMove>().transform);
    }

    public void _Init_(EnemyShootData data, float distancyOfPlayer, int countSpawnDrop, GameObject drop)
    {
        _shoot.SetData(data);
        _move.SetData(distancyOfPlayer);

        gameObject.AddComponent<EnemyDrop>().SetData(drop, countSpawnDrop);
    }

    private void Update()
    {
        _move.Move(transform);
    }
}