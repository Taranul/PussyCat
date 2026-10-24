using UnityEngine;

public class AmuseCounter : MonoBehaviour
{
    [SerializeField] private Amuse _amuse;
    [SerializeField] private Pointer _pointer;
    [SerializeField] private Transform _player;
    [SerializeField] private int _increaseSpeed;

    public float IncreasedAmuseAmount { get; private set; }

    private void Awake()
    {
        // Temp:
        Cursor.visible = false;
    }

    private void Update()
    {
        CalculateGeneratedAmuse();
    }

    private void CalculateGeneratedAmuse()
    {
        Vector2 distance = _pointer.Position - _player.position;
        float value = distance.magnitude + _pointer.CurrentSpeed; // Тут я считерил с формулой. Она неверна.
        int amuseAmount = (int)(value * Time.deltaTime * _increaseSpeed);
        IncreasedAmuseAmount = amuseAmount;
        _amuse.IncreaseTo(amuseAmount);
    }
}
