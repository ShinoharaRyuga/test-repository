using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float _addForce = 3f;
    Rigidbody2D _rb2D => GetComponent<Rigidbody2D>();
    Transform _enemyTransform = default;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        if (_enemyTransform == null)
        {
            GetEnemy();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public void GetEnemy()
    {
        _enemyTransform = EnemyGenerator.GetRamdomEnemy();

        if (_enemyTransform != null)
        {
            var moveDirection = _enemyTransform.position - transform.position;
            _rb2D.velocity = Vector2.zero;
            _rb2D.AddForce(moveDirection.normalized * _addForce, ForceMode2D.Impulse);
        }
    }
}
