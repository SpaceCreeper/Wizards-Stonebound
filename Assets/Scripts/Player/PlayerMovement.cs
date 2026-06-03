using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Component References")]
    public Rigidbody2D rb2d;
    public Collider2D col2d;

    [Header("Movement Settings")]
    public float moveSpeed;
    public float jumpForce;
    //[Space]
    //public float jumpBufferTime;
    //private float jumpBufferCounter;

    private Vector2 moveInput;

    [Header("Ground Check")]
    public LayerMask groundMask;
    private float boxHeight = 0.1f;
    private float extraCastHeight = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && IsGrounded())
        {
            rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Player Crouched");
            throw new System.NotImplementedException("Crouch not implemented yet.");
        }
    }

    bool IsGrounded()
    {
        Bounds bounds = col2d.bounds;

        RaycastHit2D hit = Physics2D.BoxCast(
            new Vector2(bounds.center.x, bounds.min.y + (boxHeight / 2)),
            new Vector2(bounds.size.x * 0.9f, boxHeight),
            0f,
            Vector2.down,
            extraCastHeight,
            groundMask
        );

        return hit.collider != null;
    }

    // Update is called once per frame
    void Update()
    {
        //if (IsGrounded())
        //{
        //    jumpBufferCounter = jumpBufferTime;
        //}
        //else
        //{
        //    jumpBufferCounter -= Time.deltaTime;
        //}
    }
    
    // Update is called once per 0.02 seconds
    void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb2d.linearVelocityY);
    }
}
