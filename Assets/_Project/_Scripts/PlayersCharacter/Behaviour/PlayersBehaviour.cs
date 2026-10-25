using UnityEngine;

public class PlayersBehaviour : MonoBehaviour
{
    private IBehaviour _currentBehaviour;

    private void Awake()
    {
        _currentBehaviour = new PassiveBehaviour();
    }

    public void ChangeBehaviour(IBehaviour behaviour)
    {
        _currentBehaviour = behaviour;
    }
}
