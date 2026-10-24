using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Pointer : MonoBehaviour
{
    private float _currentSpeed;

    public float CurrentSpeed { get { return _currentSpeed; } }
    public Vector3 Position { get { return transform.position; } }

    private void Awake()
    {
        StartCoroutine(CalculateCurrentSpeed());
    }

    private IEnumerator CalculateCurrentSpeed()
    {
        Vector2 currentPosition;
        Vector2 nextPosition;
        Vector2 delta;

        while (true)
        {
            currentPosition = transform.position;
            yield return null;
            nextPosition = transform.position;
            delta = nextPosition - currentPosition;
            _currentSpeed = delta.magnitude / Time.deltaTime;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 screenPosition = context.ReadValue<Vector2>();
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, 0f));
        worldPosition.z = 0f;
        transform.position = worldPosition;
    }
}
