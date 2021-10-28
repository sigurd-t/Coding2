using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAndAnimationScript : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpForce;

    private bool _isGrounded;
    private bool IsRunning;

    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriterenderer;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _spriterenderer = GetComponentInChildren<SpriteRenderer>();
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

        if(horizontalInput > 0)
        {
            if (_spriterenderer.flipX != false)
            {
                _spriterenderer.flipX = false;
            }

            if (_animator.GetBool("IsRunning") != true)
            {
                _animator.SetBool("IsRunning", true);
            }
        }

        else if(horizontalInput < 0)
        {
            if(_spriterenderer.flipX != true)
            {
            _spriterenderer.flipX = true;
            }

            if (_animator.GetBool("IsRunning") != true)
            {
            _animator.SetBool("IsRunning", true);
            }

        }
        else
        {
            _animator.SetBool("IsRunning", false);
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
