using UnityEngine;

public class BoxCollition : TargetCollision
{
    [SerializeField] private GameObject _destroyEffect;

    [SerializeField] private Vector3 _offset;
    private bool _isMove = false;

    public override void Invoke() => _isMove = !_isMove;

    private void Update()
    {
        if (_isMove)
            transform.position = _player.position + _offset;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NoBox"))
        {
            Instantiate(_destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}