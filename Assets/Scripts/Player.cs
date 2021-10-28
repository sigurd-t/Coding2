using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour



{
    [Header("Horizontal Movement")]
    public float moveSpeed = 10f;
    public Vector2 direction;
    private bool facingRight = true;

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;

    [Header("Physics")]
    public float maxSpeed = 7f;
    public float linearDrag = 4f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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

    //New function for modifying physics
    void modifyPhysics() 
    {
        bool changingDirections = (direction.x > 0 && rb.velocity.x < 0) || (direction.x < 0 && rb.velocity.x > 0);

        if(Mathf.Abs(direction.x) < 0.4f || changingDirections)
        {
            rb.drag = linearDrag;
        }
        else
        {
            rb.drag = 50f;
        }
    }


    // Defines Flip Function 
    void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }

}
