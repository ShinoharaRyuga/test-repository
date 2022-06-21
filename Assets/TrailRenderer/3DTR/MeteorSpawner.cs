using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] GameObject _meteor = default;
    [SerializeField] Gradient[] _colorGradients = default;
    [SerializeField] float _waitTime = 0.2f;
    [SerializeField] float _addPower = 10f;

    private void Start()
    {
        StartCoroutine(MeteorGenerator());    
    }

    IEnumerator MeteorGenerator()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            var offsetY = Random.Range(-15, 15);
            var index = Random.Range(0, _colorGradients.Length);
            var spawnPoint = new Vector3(transform.position.x, transform.position.y + offsetY, transform.position.z);
            var go = Instantiate(_meteor, spawnPoint, Quaternion.identity);
            var renderer = go.GetComponent<TrailRenderer>();
            renderer.colorGradient = _colorGradients[index];
            go.GetComponent<Rigidbody>().AddForce(transform.forward * _addPower, ForceMode.Impulse);
            Destroy(go, 3f);
        }
    }
}
