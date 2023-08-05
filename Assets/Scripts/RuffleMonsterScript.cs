using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuffleMonsterScript : MonoBehaviour
{
    public float moveSpeed;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < player.transform.position.x) {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            // transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        } else if (transform.position.x > player.transform.position.x){
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
    }
}
