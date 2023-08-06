using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 3;
    private float timer = 0f;
    private float hitboxLifetime = 0.8f;

    public MonsterHealthScript monsterHealth;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < hitboxLifetime)
        {
            timer += Time.deltaTime;
        } else {
            timer = 0;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        MonsterHealthScript monster = collision.GetComponent<MonsterHealthScript>();
        if (monster != null) {
            monster.takeDamage(damage);
        }

    }
}
