using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Transform Firepoint;
    public GameObject bullet;
    public float bulletForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
            // Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        }
        
    }

    void Shoot() {
        Instantiate(bullet, Firepoint.position, Firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Firepoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
