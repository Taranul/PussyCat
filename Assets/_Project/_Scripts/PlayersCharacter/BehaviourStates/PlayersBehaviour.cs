using UnityEngine;

public class PlayersBehaviour : MonoBehaviour
{
    [SerializeField] private FirstPhaseBehaviour _passiveBehaviour;
    [SerializeField] private SecondPhaseBehaviour _distractedBehaviour;
    [SerializeField] private ThirdPhaseBehaviour _activeBehaviour;

    private IBehaviour _currentState;

    private void Awake()
    {
        _currentState = _passiveBehaviour;
    }

    public void ChangeState(IBehaviour state)
    {
        _currentState = state;
    }
}
