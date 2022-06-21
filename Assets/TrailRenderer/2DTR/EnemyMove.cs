using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3f;
    Rigidbody2D _rb2D => GetComponent<Rigidbody2D>();
    Vector2 _moveDirection = Vector2.zero;
    bool _isMove = true;

    private void Start()
    {
        _moveDirection = Vector3.zero - transform.position;
        _moveDirection = _moveDirection.normalized * _moveSpeed;
    }

    private void Update()
    {
        var distance = Vector2.Distance(Vector2.zero, transform.position);

        if (distance <= 0.1)
        {
            _isMove = false;
            _rb2D.velocity = Vector2.zero;
            Destroy(gameObject, 0.5f);
        }
    }

    private void FixedUpdate()
    {
        if (_isMove)
        {
            _rb2D.velocity = _moveDirection;
        }
    }
}
