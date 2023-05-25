using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rd;

    private Vector3 MoveInput => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _speed * Time.fixedDeltaTime;

    private void Start()
    {
        _rd = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //if (MoveInput == Vector3.zero) return;
        Vector3 diference = transform.position + MoveInput - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        _rd.velocity = MoveInput;
    }
}