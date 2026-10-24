using UnityEngine;

public class TextPopupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _textPopupPrefab;
    [SerializeField] private AmuseCounter _amuseCounter;
    [SerializeField] private Pointer _pointer;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _textLifeTime;
    [SerializeField] private float _velosityThreshold;

    private float _timeLeft;

    private void Update()
    {
        if (_timeLeft <= 0 && _pointer.CurrentSpeed > _velosityThreshold)
        {
            _timeLeft = _spawnDelay;

            Spawn();
        }

        _timeLeft -= Time.deltaTime;
    }

    public void Spawn()
    {
        string text = _amuseCounter.IncreasedAmuseAmount.ToString();
        Vector2 position = Camera.main.WorldToScreenPoint(_pointer.Position);

        GameObject prefab = Instantiate(_textPopupPrefab, _canvas.transform);
        TextPopup textPopup = prefab.GetComponent<TextPopup>();
        textPopup.Initialize(text, position);
        Destroy(prefab, _textLifeTime);
    }
}