using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField, Tooltip("レーザーの長さ")] int _laserLength = 3;
    [SerializeField, Tooltip("移動速度")] float _moveSpeed = 2f;
    [SerializeField] Transform[] _movePositions = default;
    LineRenderer _lr => transform.GetChild(0).GetComponent<LineRenderer>();
    BoxCollider2D _collider => transform.GetChild(0).GetComponent<BoxCollider2D>();
    Vector3 move = default;
    int _currentPosition = 0;
    void Start()
    {
        var positions = new Vector3[]
        {
              new Vector3(-_laserLength, 0f, 0f),
              new Vector3(0, 0f, 0f),
        };

        _lr.SetPositions(positions);
        _collider.size = new Vector2(_laserLength, 0.1f);
        _collider.offset = new Vector2(-_laserLength / 2f, 0f);
        move = (_movePositions[_currentPosition].position - transform.position).normalized;
    }

    void Update()
    {
        var distance = Vector3.Distance(_movePositions[_currentPosition].position, transform.position);

        if (distance >= 0.1f)
        {
            transform.right = move;
            transform.position += move * _moveSpeed * Time.deltaTime;
        }
        else
        {
            _currentPosition++;
            move = (_movePositions[_currentPosition].position - transform.position).normalized;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(0, 0, 0), new Vector3(_laserLength, 0, 0));
    }
}
