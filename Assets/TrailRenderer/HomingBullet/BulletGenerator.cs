using System.Collections;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] Bullet _bullet = default;
    [SerializeField] int _firstBulletNumber = 10;
    [SerializeField] float _waitTime = 1f;
    [SerializeField] bool _isGenerate = true;

    void Start()
    {
        SetUp();

        if (_isGenerate)
        {
            StartCoroutine(Generator());
        }
    }

    IEnumerator Generator()
    {
        while (true)
        {
            yield return new WaitForSeconds(_waitTime);
            Instantiate(_bullet, Vector2.zero, Quaternion.identity);
        }
    }

    void SetUp()
    {
        for (var i = 0; i < _firstBulletNumber; i++)
        {
             Instantiate(_bullet, Vector2.zero, Quaternion.identity);
        }
    }
}
