using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
    /*
{
    private Rigidbody2D _rb;

    public float MovementSpeed;

    public float JumpForce;

    private bool IsGrounded;

    

    void Start()
    {
        _rb = GetComponent<RigidBody2D>();
    }

    void Update()
    {
        float horizontalInput = horizontalInput.GetAxisRaw("Horizontal");

        float horizontalSpeed = horizontalInput * MovementSpeed;

        _rb.velocity = new Vector2(horizontalSpeed, _rb.velocity.y);

        bool jumpInput = jumpInput.GetKeyDown(KeyCode.Space);

        if (jumpInput && IsGrounded)
        {
            _rb.velocity = new.Vector2(_rb.velocity.x, JumpForce);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsGrounded = false;
    }
}
   