using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject bullet;
    public Animator animator;
    public float moveSpeed = 3f;
    public int playerAttackPower = 1;
    public float dirX;
    public bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private bool grounded;

    
    [SerializeField] private LayerMask jumpableGround;
    public BoxCollider2D coll;
    // Update is called once per frame

    void Start() {
    }
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");

        if (dirX > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (dirX < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(dirX));

        grounded = isGrounded();

        if (grounded) {
            animator.SetBool("isJumping", false);
        } else {
            animator.SetBool("isJumping", true);
        }
        
        if (Input.GetButtonDown("Jump") && grounded) {
            rb.velocity = new Vector2(0, 4f);
        }
    }

    private bool isGrounded() {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
