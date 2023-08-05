using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnerScript : MonoBehaviour
{
    public float spawnRate = 5f;
    public float timer = 0f;
    public GameObject monster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        } else {
            timer = 0;
            spawnMonster();
        }
    }

    void spawnMonster() {
        Instantiate(monster, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }
}
