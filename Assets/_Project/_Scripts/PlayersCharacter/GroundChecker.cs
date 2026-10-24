using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private Collider2D _collider;
    private bool _isGrounded = true;

    public bool IsGrounded 
    { 
        get { return _isGrounded; } 
        private set { } 
    }

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) => _isGrounded = true;

    private void OnTriggerExit2D(Collider2D collision) => _isGrounded = false;
}
