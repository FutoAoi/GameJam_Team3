using UnityEngine;
using UnityEngine.InputSystem;

public class FutoPlayer : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private Rigidbody rb;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // PlayerInput ‚©‚çŒÄ‚Î‚ê‚é
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);

        rb.linearVelocity = new Vector3(
            move.x * _moveSpeed,
            rb.linearVelocity.y,
            move.z * _moveSpeed
        );
    }
}
