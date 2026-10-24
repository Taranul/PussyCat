using UnityEngine;
using System.Collections;
using System;

public class Amuse : MonoBehaviour
{
    [SerializeField] private int _minAmuse;
    [SerializeField] private int _maxAmuse;
    [SerializeField] private int _amuseDecreaseSpeed;

    private int _amuseAmount;
    private Coroutine _coroutine;

    public event Action<int> OnAmuseChanged;

    public int AmuseAmount { get { return _amuseAmount; } }
    public int MinAmuse { get { return _minAmuse; } }
    public int MaxAmuse { get { return _maxAmuse; } }

    private void Start()
    {
        _amuseAmount = _minAmuse;
        _coroutine = StartCoroutine(ConstantDecrease());
    }

    private void OnValidate()
    {
        if (_maxAmuse < _minAmuse)
            _maxAmuse = _minAmuse;
    }

    private IEnumerator ConstantDecrease()
    {
        while (true)
        {
            _amuseAmount -= (int)(_amuseDecreaseSpeed * Time.deltaTime);
            _amuseAmount = Mathf.Clamp(_amuseAmount, _minAmuse, _maxAmuse);
            OnAmuseChanged?.Invoke(_amuseAmount);
            yield return null;
        }
    }

    public void IncreaseTo(int value)
    {
        _amuseAmount += value;
        _amuseAmount = Mathf.Clamp(_amuseAmount, _minAmuse, _maxAmuse);
        OnAmuseChanged?.Invoke(_amuseAmount);
    }
}
