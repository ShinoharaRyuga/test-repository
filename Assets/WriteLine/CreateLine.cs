using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class CreateLine : MonoBehaviour
{
    [SerializeField, Tooltip("�O�ɏ����������c���Ĉׂ̃I�u�W�F�N�g")] GameObject _linePrefab = default;
    [SerializeField, Tooltip("���̑���")] float _lineWidth = 0.1f;
    [SerializeField, Tooltip("���ɓ����蔻�肪���邩�ǂ����e�X�g����ׂ̃I�u�W�F�N�g")] Rigidbody2D _rb2D = default;
    /// <summary>���ݏ����Ă�������ʂ����}�E�X�̈ʒu </summary>
    List<Vector3> _currentPoints = new List<Vector3>();
    /// <summary>�����Ă������\������ </summary>
    LineRenderer _lr => GetComponent<LineRenderer>();

    private void Start()
    {
        SetLineWidth(_lr);
    }
    void Update()
    {
       

        if (Input.GetButton("Fire1"))   //��������
        {    
            var mousePoint = Input.mousePosition;
            mousePoint.z = 10;
            mousePoint = Camera.main.ScreenToWorldPoint(mousePoint);
            _currentPoints.Add(mousePoint);
            _lr.positionCount = _currentPoints.Count;
            _lr.SetPositions(_currentPoints.ToArray());
        }
        else if (Input.GetButtonUp("Fire1"))    //�����I���������c���Ă����I�u�W�F�N�g�𐶐�����
        {
            var points = _currentPoints.ConvertAll(v => (Vector2)v);    //���ɓ����蔻���t����ׂ�Vector2���X�g�ɕϊ�
            var lineObj = Instantiate(_linePrefab, transform);
            var lr = lineObj.GetComponent<LineRenderer>();
            var edgeCo = lineObj.GetComponent<EdgeCollider2D>();
            edgeCo.SetPoints(points);   //���ɓ����蔻���t����
            SetLineWidth(lr);
            lr.colorGradient = _lr.colorGradient;
            lr.positionCount = _currentPoints.Count;
            lr.SetPositions(_currentPoints.ToArray());
            _currentPoints.Clear();
        }

        if (Input.GetButtonDown("Jump"))�@//�e�X�g�I�u�W�F�N�g�𗎂Ƃ�
        {
            _rb2D.gravityScale = 1;
        }
    }

    /// <summary>���̑�����ς���</summary>
    /// <param name="lr">���̑�����ς���Ώ�</param>
    void SetLineWidth(LineRenderer lr)
    {
        lr.startWidth = _lineWidth;
        lr.endWidth = _lineWidth;
    }
}
