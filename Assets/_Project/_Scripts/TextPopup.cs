using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextPopup : MonoBehaviour
{
    private TextMeshProUGUI _textPopup;

    private void Awake()
    {
        _textPopup = GetComponent<TextMeshProUGUI>();
    }

    public void Initialize(string text, Vector2 globalSpawnPosition)
    {
        _textPopup.text = text;
        transform.position = globalSpawnPosition;
    }
}
