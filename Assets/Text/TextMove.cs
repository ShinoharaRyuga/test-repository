using TMPro;
using UnityEngine;
using System.Collections;


public class TextMove : MonoBehaviour
{
    [SerializeField] float _waitTime = 1;
    TextMeshProUGUI _tmPro => GetComponent<TextMeshProUGUI>();
   
    void Start()
    {
        _tmPro.maxVisibleCharacters = 0;
        StartCoroutine(ChangeVisibleCount());
    }

    void Update()
    {
       
    }

    IEnumerator ChangeVisibleCount()
    {
        while (_tmPro.maxVisibleCharacters <_tmPro.text.Length)
        {
            yield return new WaitForSeconds(_waitTime);
            _tmPro.maxVisibleCharacters++;
        }
    }
}
