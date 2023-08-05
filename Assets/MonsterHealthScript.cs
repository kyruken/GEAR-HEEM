using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealthScript : MonoBehaviour
{
    public int maxHealth = 3;
    public int health = 3;
    public GameObject exp;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage) {
        health -= damage;

        if (health <= 0) {
            Die();
        }

    }

    void Die() {
        if (health <= 0) {
            Instantiate(exp, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            Destroy(gameObject);
        }
    }
}
