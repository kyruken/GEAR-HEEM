using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepointScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    public PlayerScript player;
    public Rigidbody2D playerRb;
    public int firepointOffsetX = 2;
    public int firepointOffsetY = 3;
    Vector2 mousePos;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        playerRb = player.rb;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal") + firepointOffsetX;
        movement.y = Input.GetAxisRaw("Vertical") + firepointOffsetY;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (movement.x > 0 && !player.m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (movement.x < 0 && player.m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

        
    }

    void FixedUpdate()
    {
        rb.MovePosition(playerRb.position + movement * player.moveSpeed * Time.deltaTime);
        Vector2 lookDir = mousePos - playerRb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
    
    private void Flip()
    {
        movement.x = movement.x - 6;
    }
}
