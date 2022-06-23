using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    [SerializeField] Transform[] _reflectPoints = default;
    LineRenderer _lr => GetComponent<LineRenderer>();
    void Start()
    {
        var reflectPoints = Array.ConvertAll(_reflectPoints, p => p.transform.position);
        _lr.positionCount = _reflectPoints.Length;
       // _lr.SetPositions(reflectPoints);
    }

    void Update()
    {
        
    }
}
