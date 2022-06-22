using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject _enemy = default;
    [SerializeField] int _firstEnemyNumber = 10;
    [SerializeField] float _waitTime = 1f;
    [SerializeField] float _radius = 3f;
    [SerializeField] bool _isGenerate = true;
    static List<Transform> _enemies = new List<Transform>();

    private void Start()
    {
        SetUp();
        if (_isGenerate)
        {
            StartCoroutine(Generator());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    public static Transform GetRamdomEnemy()
    {
        if (0 < _enemies.Count)
        {
            var index = Random.Range(0, _enemies.Count);
            return _enemies[index];
        }

        return null;

    }

    public static void RemoveEnemy(Transform enemy)
    {
        _enemies.Remove(enemy);
    }

    IEnumerator Generator()
    {
        while (true)
        {
            yield return new WaitForSeconds(_waitTime);
            var go = Instantiate(_enemy, GetSpawnPoint(), Quaternion.identity);
            _enemies.Add(go.transform);
        }
    }

    Vector2 GetSpawnPoint()
    {
        var rand = Random.Range(0, 360);
        var x = _radius * Mathf.Cos(rand);
        var y = _radius * Mathf.Sin(rand);

        return new Vector2(x, y);
    }

    void SetUp()
    {
        for (var i = 0; i < _firstEnemyNumber; i++)
        {
            var go = Instantiate(_enemy, GetSpawnPoint(), Quaternion.identity);
            _enemies.Add(go.transform);
        }
    }
}
