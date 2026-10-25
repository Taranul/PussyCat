using UnityEngine;

public class AmuseCounter : MonoBehaviour
{
    [SerializeField] private Amuse _amuse;
    [SerializeField] private Pointer _pointer;
    [SerializeField] private Transform _player;
    [SerializeField] private float _increaseSpeed;

    private readonly float _minDistance = 1f;
    private readonly float _maxDistance = 100f;

    public float IncreasedAmuseAmount { get; private set; }

    private void Update()
    {
        CalculateGeneratedAmuse();
    }

    private void CalculateGeneratedAmuse()
    {
        IncreasedAmuseAmount = CalculateGeneratedAmusePerSecond();
        _amuse.IncreaseTo(IncreasedAmuseAmount);
    }

    private float CalculateGeneratedAmusePerSecond()
    {
        Vector2 playerToPointer = _pointer.Position - _player.position;
        float clampedDistance = Mathf.Clamp(playerToPointer.magnitude, _minDistance, _maxDistance);
        float generatedAmuse = _pointer.CurrentSpeed / clampedDistance;
        float generatedAmusePerSecond = generatedAmuse * Time.deltaTime * _increaseSpeed;
        return generatedAmusePerSecond;
    }
}
