using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public int playerAttackPower;
    public int bulletPierceLimit;
    private int currentPierceCount = 1;

    public MonsterHealthScript monsterHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentPierceCount = 0;
        playerAttackPower = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().playerAttackPower;
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        MonsterHealthScript monster = collision.GetComponent<MonsterHealthScript>();
        if (monster != null) {
            monster.takeDamage(playerAttackPower);
            currentPierceCount++;
            if (currentPierceCount >= bulletPierceLimit)
            {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }


    }
}
