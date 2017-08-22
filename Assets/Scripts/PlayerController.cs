using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    private float moveVelocity;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D rb2d;
    private Animator anim;
    private bool grounded;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		moveVelocity = 0f;

		if (Input.GetAxisRaw("Vertical") == 1 && grounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            //rb2d.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), rb2d.velocity.y);
        	moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");
        }

        rb2d.velocity = new Vector2(moveVelocity, rb2d.velocity.y);

        if (rb2d.velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (rb2d.velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        anim.SetFloat("speed", Mathf.Abs(rb2d.velocity.x));
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
}
