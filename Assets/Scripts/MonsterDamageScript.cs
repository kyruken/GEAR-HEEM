using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamageScript : MonoBehaviour
{
    public int damage;
    private PlayerHealthScript playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            playerHealth.takeDamage(damage);
        }
    }   
}
