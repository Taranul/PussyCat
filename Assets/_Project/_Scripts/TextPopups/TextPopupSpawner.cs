using System.Collections;
using UnityEngine;

public class TextPopupSpawner : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameObject _textPopupPrefab;
    [SerializeField] private AmuseCounter _amuseCounter;
    [SerializeField] private Pointer _pointer;
    [SerializeField] private Canvas _canvasRoot;

    [Header("Parameters")]
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _textLifeTime;
    [SerializeField] private float _minimumPointerVelocityToSpawnText;

    private Coroutine _coroutine;

    private void Update()
    {
        TryToSpawnText();
    }

    private void TryToSpawnText()
    {
        if (_coroutine != null || _pointer.CurrentSpeed < _minimumPointerVelocityToSpawnText) return;

        _coroutine = StartCoroutine(DelaySpawn());
    }

    private IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(_spawnInterval);

        Spawn();

        _coroutine = null;
    }

    public void Spawn()
    {
        string number = _amuseCounter.CalculateGeneratedAmusePer(_spawnInterval).ToString("f2");
        Vector2 position = Camera.main.WorldToScreenPoint(_pointer.Position);

        GameObject prefab = Instantiate(_textPopupPrefab, _canvasRoot.transform);
        TextPopup textPopup = prefab.GetComponent<TextPopup>();
        textPopup.Initialize(number, position);
        Destroy(prefab, _textLifeTime);
    }
}