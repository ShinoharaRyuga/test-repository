using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] Bullet _bullet = default;
    [SerializeField] int _firstBulletNumber = 10;
    [SerializeField] float _waitTime = 1f;

    void Start()
    {
        SetUp();
        StartCoroutine(Generator());
    }

    IEnumerator Generator()
    {
        while (true)
        {
            yield return new WaitForSeconds(_waitTime);
            var bullet = Instantiate(_bullet, Vector2.zero, Quaternion.identity);
            bullet.GetEnemy();
        }
    }

    void SetUp()
    {
        for (var i = 0; i < _firstBulletNumber; i++)
        {
            var bullet = Instantiate(_bullet, Vector2.zero, Quaternion.identity);
            bullet.GetEnemy();
        }
    }
}
