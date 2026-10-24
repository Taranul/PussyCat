using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Pointer _pointer;

    private InputSystem_Actions _actions;

    private void Awake()
    {
        _actions = new InputSystem_Actions();

        _actions.Player.Look.performed += _pointer.OnLook;
    }

    private void OnEnable()
    {
        _actions.Enable();
    }

    private void OnDisable()
    {
        _actions.Disable();
    }
}
