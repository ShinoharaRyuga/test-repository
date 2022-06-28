using System.Collections.Generic;
using UnityEngine;

public class CreateLine : MonoBehaviour
{
    [SerializeField, Tooltip("前に書いた線を残して為のオブジェクト")] LineRenderer _linePrefab = default;
    [SerializeField, Tooltip("線の太さ")] float _lineWidth = 0.1f;
    /// <summary>現在書いている線が通ったマウスの位置 </summary>
    List<Vector3> _currentPoints = new List<Vector3>();
    /// <summary>書いている線を表示する </summary>
    LineRenderer _lr => GetComponent<LineRenderer>();

    private void Start()
    {
        SetLineWidth(_lr);
    }
    void Update()
    {
        if (Input.GetButton("Fire1"))   //線を書く
        {
            var mousePoint = Input.mousePosition;
            mousePoint.z = 10;
            mousePoint = Camera.main.ScreenToWorldPoint(mousePoint);
            _currentPoints.Add(mousePoint);
            _lr.positionCount = _currentPoints.Count;
            _lr.SetPositions(_currentPoints.ToArray());
        }
        else if (Input.GetButtonUp("Fire1"))    //書き終えた線を残しておくオブジェクトを生成する
        {
            var lineObj = Instantiate(_linePrefab, transform);
            SetLineWidth(lineObj);
            lineObj.colorGradient = _lr.colorGradient;
            lineObj.positionCount = _currentPoints.Count;
            lineObj.SetPositions(_currentPoints.ToArray());
            _currentPoints.Clear();
        }
    }

    /// <summary>線の太さを変える</summary>
    /// <param name="lr">線の太さを変える対象</param>
    void SetLineWidth(LineRenderer lr)
    {
        lr.startWidth = _lineWidth;
        lr.endWidth = _lineWidth;
    }
}
