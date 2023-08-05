using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShootScript : MonoBehaviour
{
    public GameObject bullet;
    public float timer = 0f;
    public float shootRate = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < shootRate) 
        {
            timer += Time.deltaTime;
        } else 
        {
            timer = 0;
                    Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);

        }
    }
}
