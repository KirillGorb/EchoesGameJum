using UnityEngine;

[System.Serializable]
public class MoveEnemy
{
    public float DistancyMove;

    [SerializeField] private float _speed;
    [SerializeField] private float _exp = 0.4f;

    private Rigidbody2D _rd;
    private Transform _player;

    public void SetData(Rigidbody2D rd, Transform playerTransform)
    {
        _rd = rd;
        _player = playerTransform;
    }

    public void SetData(float newDistancyMove) => DistancyMove = newDistancyMove;

    public void Move(Transform transform)
    {
        Vector3 diference = _player.position - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        if (Vector2.Distance(_player.position, transform.position) >= DistancyMove + _exp)
            _rd.MovePosition(Vector2.LerpUnclamped(transform.position, _player.position, _speed * Time.deltaTime));
        else if (Vector2.Distance(_player.position, transform.position) <= DistancyMove)
            _rd.MovePosition(Vector2.LerpUnclamped(transform.position, _player.position, -_speed * Time.deltaTime));
    }
}