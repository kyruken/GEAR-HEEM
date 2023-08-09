using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMonsterScript : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private MonsterHealthScript monsterHealth;
    private GameObject player;
    private float jumpRate = 5f;
    private float timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        monsterHealth = this.GetComponent<MonsterHealthScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < player.transform.position.x) {
            transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
        } else {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }

        if (timer < jumpRate)
        {
            timer += Time.deltaTime;
        } else 
        {
            rb.velocity = new Vector2(0, 1.5f);
            timer = 0;
        }
        
    }

}
