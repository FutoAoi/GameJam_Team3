using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveInputSystem : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashSpeed = 10f;

    private Rigidbody rb;
    private Vector2 moveInput;
    private bool isDash;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);

        float speed = isDash ? dashSpeed : moveSpeed;

        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        isDash = context.ReadValueAsButton();
    }
}