using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMonsterScript : MonoBehaviour
{
    public float moveSpeed;
    private MonsterHealthScript monsterHealth;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
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
        
    }

}
