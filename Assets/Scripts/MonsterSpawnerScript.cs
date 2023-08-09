using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnerScript : MonoBehaviour
{
    public float points;
    public float neededPointsForSpawn;
    public float addPoints;
    private float timer = 0f;
    private float oneSecond = 1f;
    private float seconds = 0f;
    private float a = 35f;
    private float b = 100f;
    private float c = 5f;
    public GameObject monster;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            if (timer < oneSecond)
            {
                timer += Time.deltaTime;
            }
            else 
            {
                timer = 0;
                seconds += 1f;
                points += addPoints;
                addPoints = (seconds*a)/(seconds+b) + c;
            }

        if (points >= neededPointsForSpawn)
        {
            spawnMonster();
            points -= neededPointsForSpawn;
        }

    }

    void spawnMonster() 
    {
        Instantiate(monster, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }
}
