using UnityEngine;

public class ChangeGradient : MonoBehaviour
{
    [SerializeField] float _fadeColorTime = 3f;
    [SerializeField] Gradient[] _colorGradients = default;
    TrailRenderer _trailRenderer = default;
    float _currentTime = 0f;

    void Update()
    {
        _currentTime += Time.deltaTime;
        var timeRate = Mathf.Min(1f, _currentTime / _fadeColorTime);
       // _trailRenderer.colorGradient = _trailRenderer.colorGradient.Evaluate(timeRate);
    }
}
