using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    [SerializeField] float _correctionStrength = 1f;
    Rigidbody2D _rb2D => GetComponent<Rigidbody2D>();
    Transform _enemyTransform = default;
    Vector3 _dirction = Vector3.zero;

    private void Start()
    {
        // Destroy(gameObject, 3f);
        _enemyTransform = EnemyGenerator.GetRamdomEnemy();
    }

    private void Update()
    {
        if (_enemyTransform == null)
        {
            _enemyTransform = EnemyGenerator.GetRamdomEnemy();
        }

        BulletMove();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            EnemyGenerator.RemoveEnemy(collision.transform);
            //Destroy(gameObject);
        }
    }

    public void GetEnemy()
    {

    }

    public void BulletMove()
    {
        Vector3 cor = (_enemyTransform.position - transform.position).normalized * _correctionStrength * Time.deltaTime;
        _dirction = (_dirction + cor).normalized;
        transform.position += _dirction * _speed * Time.deltaTime;
    }
}


