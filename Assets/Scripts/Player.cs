using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour



{
    [Header("Horizontal Movement")]
    public float moveSpeed = 10f;
    public Vector2 direction;
    private bool facingRight = true;

    [Header("Vertical Movement")]
    public float jumpSpeed = 15f;

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;
    public LayerMask groundLayer;

    [Header("Physics")]
    public float maxSpeed = 6f;
    public float linearDrag = 4f;
    public float gravity = 1;
    public float fallMultiplier = 5;

    [Header("Collision")]
    public bool onGround = false;
    public float groundLength = 0.6f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Raycast
        onGround = Physics2D.Raycast(transform.position, Vector2.down, groundLength, groundLayer);

        // Jump
        if(Input.GetButtonDown("Jump") && onGround)
        {
            Jump();
        }

        //Gets input
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    // Fixed Update to avoid runtime issues
    void FixedUpdate()
    {
        moveCharacter(direction.x);
    }
    void moveCharacter(float horizontal)
    {
        //Horizontal Movement
        rb.AddForce(Vector2.right * horizontal * moveSpeed);

        //Finds speed for horizontal parameter
        animator.SetFloat("horizontal", Mathf.Abs(rb.velocity.x));

        // Sets conditions for Flip Function
        if(horizontal > 0 && !facingRight || (horizontal < 0 && facingRight))
        {
            Flip();
        }
        //Check that velocity never exceeds maxSpeed
        if(Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
    }

    //New function for modifying physics
    void modifyPhysics() 
    {
        bool changingDirections = (direction.x > 0 && rb.velocity.x < 0) || (direction.x < 0 && rb.velocity.x > 0);

        if (onGround)
        {
            if (Mathf.Abs(direction.x) < 0.4f || changingDirections)
            {
                rb.drag = linearDrag;
            }
            else
            {
                rb.drag = 0f;
            }
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = gravity;
            rb.drag = linearDrag * 0.15f;
            if (rb.velocity.y < 0)
            {
                rb.gravityScale = gravity * fallMultiplier;
            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb.gravityScale = gravity * (fallMultiplier / 2);
            }
        }
    }


    // Defines Flip Function 
    void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }

    // Draws Gizmo to make groundLength easilly adjustable
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundLength);
    }
}
