using UnityEngine;

[System.Serializable]
public class MoveEnemy
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distancyMove;
    [SerializeField] private float _exp = 0.4f;

    private Rigidbody2D _rd;
    private Transform _player;

    public void SetData(Rigidbody2D rd, Transform playerTransform)
    {
        _rd = rd;
        _player = playerTransform;
    }

    public void SetData(float newDistancyMove) => _distancyMove = newDistancyMove;

    public void Move(Transform transform)
    {
        Rotation(transform);
        Movement(transform);
    }

    private void Rotation(Transform transform)
    {
        Vector3 diference = _player.position - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
    }

    private void Movement(Transform transform)
    {
        if (Vector2.Distance(_player.position, transform.position) >= _distancyMove + _exp)
            RigidbodyMove(transform);
        else if (Vector2.Distance(_player.position, transform.position) <= _distancyMove)
            RigidbodyMove(transform, false);
    }

    private void RigidbodyMove(Transform transform, bool isMove = true) =>
         _rd.MovePosition(Vector2.LerpUnclamped(transform.position, _player.position, (isMove ? 1 : -1) * _speed * Time.deltaTime));
}