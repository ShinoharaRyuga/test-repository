using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    [SerializeField] float _normalizedTime = 1f;
    [SerializeField] float _correctionStrength = 1f;
    [SerializeField, Tooltip("true=ノーマライズする　false=ノーマライズを止める")] bool _isChangeNormalized = false;
    Rigidbody2D _rb2D => GetComponent<Rigidbody2D>();
    Transform _enemyTransform = default;
    Vector3 _dirction = Vector3.zero;
    bool _isnormalized = false;

    private void Start()
    {
        _enemyTransform = EnemyGenerator.GetRamdomEnemy();
        _isChangeNormalized = !_isChangeNormalized;
        StartCoroutine(ChangeNormalized());
    }

    private void Update()
    {
        if (_enemyTransform == null)
        {
            _enemyTransform = EnemyGenerator.GetRamdomEnemy();
            _isChangeNormalized = !_isChangeNormalized;
            StartCoroutine(ChangeNormalized());
        }

        BulletMove();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            EnemyGenerator.RemoveEnemy(collision.transform);
            // Destroy(gameObject);
        }
    }

    public void GetEnemy()
    {

    }

    public void BulletMove()
    {
        if (_isnormalized)
        {
            Vector3 cor = (_enemyTransform.position - transform.position).normalized * _correctionStrength * Time.deltaTime;
            _dirction = (_dirction + cor).normalized;
            transform.position += _dirction * _speed * Time.deltaTime;
        }
        else
        {
            Vector3 cor = (_enemyTransform.position - transform.position).normalized * _correctionStrength * Time.deltaTime;
            _dirction = (_dirction + cor);
            transform.position += _dirction * _speed * Time.deltaTime;
        }


    }

    /// <summary>一定時間後に設定した処理を行う </summary>
    IEnumerator ChangeNormalized()
    {
        yield return new WaitForSeconds(_normalizedTime);
        _isnormalized = _isChangeNormalized;
    }
}


