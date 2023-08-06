using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeScript : MonoBehaviour
{
    public Transform Firepoint;
    public GameObject swordHitbox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3")) {
            Swing();
            // Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        }  
    }

    void Swing() 
    {
        Instantiate(swordHitbox, Firepoint.position, Firepoint.rotation);
    }
}
