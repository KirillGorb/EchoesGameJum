using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rd;

    private Vector3 MoveInput => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _speed;

    private void Start()
    {
        _rd = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RigidbodyMove();
        Rotation();
    }

    private void RigidbodyMove() => _rd.velocity = MoveInput;

    private void Rotation()
    {
        if (MoveInput.magnitude == 0) return;
        float rotateZ = Mathf.Atan2(MoveInput.y, MoveInput.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
    }
}