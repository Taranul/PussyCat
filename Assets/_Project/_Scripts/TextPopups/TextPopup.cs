using UnityEngine;
using TMPro;
using System.Collections;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextPopup : MonoBehaviour
{
    [SerializeField] private float _animationSpeed;

    private TextMeshProUGUI _textPopup;
    private Coroutine _coroutine;

    private void Awake()
    {
        _textPopup = GetComponent<TextMeshProUGUI>();
        _coroutine = StartCoroutine(StartAnimation());
    }

    public void Initialize(string text, Vector2 globalSpawnPosition)
    {
        _textPopup.text = text;
        transform.position = globalSpawnPosition;
    }

    private IEnumerator StartAnimation()
    {
        while (true)
        {
            transform.position += new Vector3(0, Time.deltaTime * _animationSpeed, 0);
            yield return null;
        }
    }
}
