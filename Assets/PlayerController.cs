//����̓T���v���̃N���X�ɂȂ�܂��B
//�Q�l�ɂ��Ă��������B
//�N���X���\������ϐ���֐��̏��Ԃ͉��L�̂Ƃ���ɂ��Ă�������

//�@const��V���O���g���p�^�[���i�C���X�^���g�j���`����
//�A�C���X�y�N�^�[�ő��삵�����ϐ����`����
//�Bprivate�ϐ����`����
//�Cpublic�ϐ����`����(�v���p�e�B��)
//�DUnity�W���̊֐� (start��Update)
//�Eprivete�֐�
//�Fpublic�֐�


using UnityEngine;

/// <summary>�v���C���[���Ǘ�����ׂ̃N���X </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>�ő�̗� </summary>
    const int MAX_LIFE = 5;

    [SerializeField, Header("�Q�[���J�n���̃��C�t")]
    int _startLife = 3;
    [SerializeField, Header("�v���C���[�̈ړ����x")]
    float _moveSpeed = 5f;
    [SerializeField, Tooltip("�W�����v��")]
    float _jumpPower = 10f;

    /// <summary>���݂̗̑� </summary>
    int _currentLife = 0;
    /// <summary>�U���� </summary>
    int _attackPower = 10;
    /// <summary>�A�C�e���̏����� </summary>
    int _currentItemCount = 0;

    /// <summary>���݂̗̑� </summary>
    public int CurrentLife { get => _currentLife; set => _currentLife = value; }
    /// <summary>�U���� </summary>
    public int AttackPower { get => _attackPower; set => _attackPower = value; }

    void Start()
    {
        _currentLife = _startLife;
    }

    void Update()
    {
        PlayerMove();
    }

    /// <summary>�ړ����� </summary>
    private void PlayerMove()
    {
        //�ړ�����
    }

    /// <summary>�G����_���[�W���󂯂� </summary>
    public void GetDamage(int damage)
    {
         _currentLife -= damage;

        if (_currentLife <= 0)
        {
            Debug.Log("��");
        }
    }

    /// <summary>
    /// �G�Ƀ_���[�W��^����
    /// �A�j���[�V�����g���K�[�ŌĂяo��
    /// </summary>
    public void Attack()
    {
        var hitObjects = Physics.OverlapSphere(Vector3.zero, 10f);  //�͈͓��̃I�u�W�F�N�g���擾

        foreach (var obj in hitObjects)
        {
            if (obj.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("�_���[�W�^����");
            }
        }
    }
}
