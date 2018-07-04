using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed, jumpForce;
    public KeyCode left, right, jump;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update () {
 
        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }else if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if(grounded && Input.GetKey(jump))
        {
            rb.AddForce(new Vector2(0,jumpForce));
        }
 
		
	}
}
