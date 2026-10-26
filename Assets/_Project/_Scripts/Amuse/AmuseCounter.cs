using System.Collections;
using UnityEngine;

public class AmuseCounter : MonoBehaviour
{
    [SerializeField] private Amuse _amuse;
    [SerializeField] private Pointer _pointer;
    [SerializeField] private Transform _player;
    [SerializeField] private float _increaseSpeed;

    private readonly float _minDistance = 1f;
    private readonly float _maxDistance = 100f;

    private Coroutine _coroutine;
    private float _generatedAmusePerTime;

    private void Update()
    {
        _amuse.IncreaseTo(CalculateGeneratedAmusePerFrame());
    }

    public float CalculateGeneratedAmusePer(float timeInSeconds)
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(CalculateGeneratedAmuse(timeInSeconds));
        }

        return _generatedAmusePerTime;
    }

    private float CalculateGeneratedAmusePerFrame()
    {
        Vector2 playerToPointer = _pointer.Position - _player.position;
        float clampedDistance = Mathf.Clamp(playerToPointer.magnitude, _minDistance, _maxDistance);
        float generatedAmuse = _pointer.CurrentSpeed / clampedDistance;
        float generatedAmusePerFrame = generatedAmuse * Time.deltaTime * _increaseSpeed;
        return generatedAmusePerFrame;
    }

    private IEnumerator CalculateGeneratedAmuse(float timeInSeconds)
    {
        float generatedAmuse = 0f;
        float elapsedTime = 0f;

        while (elapsedTime < timeInSeconds)
        {
            generatedAmuse += CalculateGeneratedAmusePerFrame();
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _coroutine = null;
        _generatedAmusePerTime = generatedAmuse;
    }
}
