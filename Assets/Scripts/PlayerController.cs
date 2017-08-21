using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
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
		if (Input.GetAxisRaw("Vertical") == 1 && grounded)
        {
            rb2d.velocity = new Vector2(0, jumpHeight);
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            rb2d.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), rb2d.velocity.y);
        }

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
