using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBulletScript : MonoBehaviour
{
    public PlayerHealthScript playerHealth;
    public float bulletSpeed = 1f;
    public GameObject player;
    private float currentPlayerXPos;
    private float currentPlayerYPos;
    private bool haveSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!haveSpawned)
        {
            currentPlayerXPos = player.transform.position.x;
            currentPlayerYPos = player.transform.position.y;
            haveSpawned = true;
        }
        
        if (transform.position.x < currentPlayerXPos) {
            transform.position = transform.position + (Vector3.right * bulletSpeed) * Time.deltaTime;
        } else {
            transform.position = transform.position + (Vector3.left * bulletSpeed) * Time.deltaTime;
        }

        if (transform.position.y < currentPlayerYPos) {
            transform.position = transform.position + (Vector3.up * bulletSpeed) * Time.deltaTime;
        } else {
            transform.position = transform.position + (Vector3.down * bulletSpeed) * Time.deltaTime;
        }

        if (transform.position.x == currentPlayerXPos && transform.position.y == currentPlayerYPos)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player") 
        {
            playerHealth.takeDamage(1);
        } 
    }
}
