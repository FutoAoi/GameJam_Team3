using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveInputSystem : MonoBehaviour
{
    public bool CanMove = false;

    [Header("通常移動速度")]
    [SerializeField] private float _moveSpeed = 5f;
    [Header("Shiftダッシュ速度")]
    [SerializeField] private float _dashSpeed = 10f;
    [SerializeField] private float _jumpPower = 7f;
    [SerializeField] private float _rotateSpeed = 1.0f;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private AudioClip _walk;
    [SerializeField] private AudioSource _source;

    private AudioManager _audioManager;
    private Rigidbody _rb;
    private Vector2 _moveInput;
    private Vector3 _moveDirection;
    private bool _isDash;
    private bool _isWalk;
    private bool _isGrounded = true;
    private float _nowSpeed;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _moveDirection = new Vector3(_moveInput.x, 0f, _moveInput.y);

        _nowSpeed = _isDash ? _dashSpeed : _moveSpeed;

        _rb.linearVelocity = new Vector3(_moveDirection.x * _nowSpeed, _rb.linearVelocity.y, _moveDirection.z * _nowSpeed
        );
        if(_moveDirection.magnitude > 0.1)
        {
            if(!_isWalk)
            {
                _isWalk = true;
                _source.Play();
            }
            Quaternion targetRotation = Quaternion.LookRotation(_moveDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotateSpeed * Time.fixedDeltaTime);
        }
        else
        {
            if(_isWalk)
            {
                _isWalk = false;
                _source.Stop();
            }
        }
        _playerAnimator.SetFloat("MoveSpeed", _moveDirection.magnitude);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!CanMove) return;
        _moveInput = context.ReadValue<Vector2>();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (!CanMove) return;
        _isDash = context.ReadValueAsButton();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!CanMove) return;
        if (!_isGrounded) return;
        _rb.linearVelocity = new Vector3(
        _rb.linearVelocity.x,
        0f,
        _rb.linearVelocity.z
        );

        _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        _isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
}