using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpForce;

    private bool _isGrounded;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        float horizontalSpeed = horizontalInput * MovementSpeed;

        _rb.velocity = new Vector2(horizontalSpeed, _rb.velocity.y);

        bool jumpInput = Input.GetKeyDown(KeyCode.Space);

        if(jumpInput && _isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, JumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isGrounded = false;
    }
}
