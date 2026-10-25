using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    //[Tooltip("X - контроль длительности прыжка\nY - контроль резкости")]
    [SerializeField] private AnimationCurve _gravityCurve;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpCooldown;
    [SerializeField] private Transform _pointer;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidbody;
    private Coroutine _coroutine = null;
    private float _jumpDuration;
    private float _jumpCooldownCounter;
    private float _timeCounter;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _jumpCooldownCounter = _jumpCooldown;
    }

    private void FixedUpdate()
    {
        if (_coroutine == null)
        {
            StartCoroutine(JumpAnticipation());
        }

        if (_groundChecker.IsGrounded)
        {
            _jumpCooldownCounter += Time.deltaTime;
        }
    }

    private IEnumerator JumpAnticipation()
    {
        if (!_groundChecker.IsGrounded || _jumpCooldown > _jumpCooldownCounter) yield break;

        Vector3 jumpDirection = _pointer.position - transform.position;
        Vector3 jumpForce = jumpDirection.normalized * _jumpForce;

        _coroutine = StartCoroutine(Jump(jumpForce));
        yield return _coroutine;
        _coroutine = null;

        _jumpCooldownCounter = 0f;
    }

    public IEnumerator Jump(Vector3 force)
    {
        _timeCounter = 0f;
        _jumpDuration = _gravityCurve.keys[^1].time - _gravityCurve.keys[0].time;
        _rigidbody.AddForce(force, ForceMode2D.Impulse);

        while (_timeCounter < _jumpDuration)
        {
            _rigidbody.gravityScale = _gravityCurve.Evaluate(_timeCounter / _jumpDuration);
            _timeCounter += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}
