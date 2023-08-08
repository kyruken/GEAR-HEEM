using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuffleMonsterScript : MonoBehaviour
{
    public float moveSpeed;
    public GameObject pointA;
    public GameObject pointB;
    private GameObject player;
    private Rigidbody2D rb;
    private Transform currentPoint;
    private float moveBoundsX1 = -7.18f;
    private float moveBoundsX2 = 10f;
    private float moveRange;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pointA = GameObject.FindGameObjectWithTag("pointA");
        pointB = GameObject.FindGameObjectWithTag("pointB");
        player = GameObject.FindGameObjectWithTag("Player");
        moveRange = Random.Range(moveBoundsX1, moveBoundsX2);
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        else 
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
        // if (transform.position.x < player.transform.position.x) {
        //     transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        //     // transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        // } else if (transform.position.x > player.transform.position.x){
        //     transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        // }
    }
}
