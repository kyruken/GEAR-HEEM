using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBulletScript : MonoBehaviour
{
    public PlayerHealthScript playerHealth;
    public float bulletSpeed = 1f;
    public GameObject player;
    private Rigidbody2D rb;
    private float currentPlayerXPos;
    private float currentPlayerYPos;
    private bool haveSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player") 
        {
            playerHealth.takeDamage(1);
            Destroy(gameObject);
        } else if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
