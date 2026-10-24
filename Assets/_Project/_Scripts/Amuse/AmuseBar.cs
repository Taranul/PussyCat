using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class AmuseBar : MonoBehaviour
{
    [SerializeField] private Amuse _amuse;
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();

        _slider.minValue = _amuse.MinAmuse;
        _slider.maxValue = _amuse.MaxAmuse;
        _slider.value = _slider.minValue;
    }

    private void OnEnable()
    {
        _amuse.OnAmuseChanged += ChangeBarValue;
    }

    private void OnDisable()
    {
        _amuse.OnAmuseChanged -= ChangeBarValue;
    }

    private void ChangeBarValue(int newValue)
    {
        _slider.value = newValue;
    }
}
