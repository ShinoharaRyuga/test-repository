using System.Collections.Generic;
using UnityEngine;

public class CreateLine : MonoBehaviour
{
    [SerializeField, Tooltip("�O�ɏ����������c���Ĉׂ̃I�u�W�F�N�g")] LineRenderer _linePrefab = default;
    [SerializeField, Tooltip("���̑���")] float _lineWidth = 0.1f;
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
            var lineObj = Instantiate(_linePrefab, transform);
            SetLineWidth(lineObj);
            lineObj.colorGradient = _lr.colorGradient;
            lineObj.positionCount = _currentPoints.Count;
            lineObj.SetPositions(_currentPoints.ToArray());
            _currentPoints.Clear();
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
