using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class CreateLine : MonoBehaviour
{
    [SerializeField, Tooltip("前に書いた線を残して為のオブジェクト")] GameObject _linePrefab = default;
    [SerializeField, Tooltip("線の太さ")] float _lineWidth = 0.1f;
    [SerializeField, Tooltip("線に当たり判定があるかどうかテストする為のオブジェクト")] Rigidbody2D _rb2D = default;
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
            var points = _currentPoints.ConvertAll(v => (Vector2)v);    //線に当たり判定を付ける為にVector2リストに変換
            var lineObj = Instantiate(_linePrefab, transform);
            var lr = lineObj.GetComponent<LineRenderer>();
            var edgeCo = lineObj.GetComponent<EdgeCollider2D>();
            edgeCo.SetPoints(points);   //線に当たり判定を付ける
            SetLineWidth(lr);
            lr.colorGradient = _lr.colorGradient;
            lr.positionCount = _currentPoints.Count;
            lr.SetPositions(_currentPoints.ToArray());
            _currentPoints.Clear();
        }

        if (Input.GetButtonDown("Jump"))　//テストオブジェクトを落とす
        {
            _rb2D.gravityScale = 1;
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
