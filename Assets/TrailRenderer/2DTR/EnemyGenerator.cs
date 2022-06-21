using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject _enemy = default;
    [SerializeField] float _waitTime = 1f;
    [SerializeField] float _radius = 3f;

    private void Start()
    {
        StartCoroutine(Generator());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    IEnumerator Generator()
    {
        while (true)
        {
            yield return new WaitForSeconds(_waitTime);
            Instantiate(_enemy, GetSpawnPoint(), Quaternion.identity);
        }
    }

    Vector2 GetSpawnPoint()
    {
        var rand = Random.Range(0, 360);
        var x = _radius * Mathf.Cos(rand);
        var y = _radius * Mathf.Sin(rand);

        return new Vector2(x, y);
    }
}
