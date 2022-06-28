using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser2Manager : MonoBehaviour
{
    [SerializeField] Laser2 _laser2 = default;
    [SerializeField] Transform[] _reflectPoints = default;
    bool _isArrival = false;
    int _currentPoint = 0;
    void Start()
    {
        GenerateLaser();
    }

    void Update()
    {
        if (_isArrival && _currentPoint < _reflectPoints.Length - 1)
        {
            _currentPoint++;
            GenerateLaser();
            _isArrival = false;
        }
        else if(_reflectPoints.Length - 1 <= _currentPoint)
        {
            Destroy(gameObject, 2f);
        }

    }

    public void PointArrival()
    {
        _isArrival = true;
    }

    private void GenerateLaser()
    {
        var go = Instantiate(_laser2, transform);
        go.PointArrival += PointArrival;
        if (_currentPoint - 1 < 0)
        {
            go.SetPoints(transform, _reflectPoints[_currentPoint]);
        }
        else
        {
            go.SetPoints(_reflectPoints[_currentPoint - 1], _reflectPoints[_currentPoint]);
        }

    }
}
