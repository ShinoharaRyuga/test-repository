using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser2 : MonoBehaviour
{  
    [SerializeField] Transform _endPoint = default;
    [SerializeField] float _speed = 2f;

    Vector3 _moveDirection = Vector3.zero;
    Transform _startPoint = default;
    bool _isArrival = false;
    public event Action PointArrival;
    LineRenderer _lr => GetComponent<LineRenderer>();
    private void Start()
    {
        _moveDirection = (_endPoint.position - _startPoint.position).normalized;
        transform.position = _startPoint.position;
    }

    void Update()
    {
        var distance = Vector3.Distance(_endPoint.position, transform.position);
      
        if (distance <= 0.05f && !_isArrival)
        {
            _isArrival = true;
            PointArrival.Invoke();
        }
        else if(!_isArrival)
        {
            transform.position += _moveDirection * _speed * Time.deltaTime;
        }

        var positions = new Vector3[]
        {
              _startPoint.position,
              transform.position,
        };

        _lr.SetPositions(positions);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }

    public void SetPoints(Transform startPoint, Transform endPoint)
    {
        _startPoint = startPoint;
        _endPoint = endPoint;
    }
}
