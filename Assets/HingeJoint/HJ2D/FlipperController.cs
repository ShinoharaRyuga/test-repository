using UnityEngine;

/// <summary>
/// �t���b�p�[�𑀍삷�� 
/// �t���b�p�[�̊p�x�����̓C���X�y�N�^�[����
/// �ݒ肵������������₷���Ǝv��
/// </summary>
public class FlipperController : MonoBehaviour
{
    [SerializeField, Tooltip("���t���b�p�[")] HingeJoint2D _leftFlipper = default;
    [SerializeField, Tooltip("�E�t���b�p�[")] HingeJoint2D _rightFlipper = default;
    [SerializeField, Header("�t���b�p�[�̈ړ����x")] float _flipperSpeed = 500;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))�@//���t���b�p�[�𑀍�@�����Ă���Ԃ͏グ����Ԃ��ێ�����
        {
            LeftUp();
        }
        else
        {
            LeftDown();
        }

        if (Input.GetKey(KeyCode.D))  //�E�t���b�p�[�𑀍�
        {
            RightUp();
        }
        else 
        {
            RightDown();
        }
    }

    /// <summary>
    /// �E�t���b�p�[���グ�� 
    /// </summary>
    void RightUp()
    {
        _rightFlipper.useMotor = true;              //�t���b�p�[�ɗ͂�������
        JointMotor2D moter = _rightFlipper.motor;�@ //JointMotor2D���g��Ȃ��ƃt���b�p�[�̈ړ����x��ύX�o���Ȃ��@
        moter.motorSpeed = _flipperSpeed;
        _rightFlipper.motor = moter;                //�ύX�������x��K�p����
    }

    /// <summary>
    /// �E�t���b�p�[�������� 
    /// </summary>
    void RightDown()
    {
        _rightFlipper.useMotor = false;�@
        JointMotor2D moter = _rightFlipper.motor;
        moter.motorSpeed = -_flipperSpeed;�@        //�t���b�p�[��������ׂɃ}�C�i�X�̒l�ɂ���@
        _rightFlipper.motor = moter;
    }

    /// <summary>
    /// ���t���b�p�[���グ�� 
    /// </summary>
    void LeftUp()
    {
        _leftFlipper.useMotor = true;
        JointMotor2D moter = _leftFlipper.motor;
        moter.motorSpeed = -_flipperSpeed;          //�E�Ƃ͋t�̓�����������ׂɃ}�C�i�X�̒l�ɂ���
        _leftFlipper.motor = moter;
    }

    /// <summary>
    /// ���t���b�p�[�������� 
    /// </summary>
    void LeftDown()
    {
        _leftFlipper.useMotor= false;
        JointMotor2D moter = _leftFlipper.motor;
        moter.motorSpeed = _flipperSpeed;          
        _leftFlipper.motor = moter;
    }
}
