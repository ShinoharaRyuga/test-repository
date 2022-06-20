using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 4f;
    Rigidbody _rb => GetComponent<Rigidbody>();

    Vector3 _move = default;
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        _move = new Vector3(h, 0, v).normalized * _moveSpeed;
    }

    private void FixedUpdate()
    {
        if (_move != Vector3.zero)
        {
            _rb.velocity = _move;
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }
    }
}
