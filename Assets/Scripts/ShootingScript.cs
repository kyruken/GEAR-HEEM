using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Transform Firepoint;
    public Animator animator;
    public GameObject bullet;
    public float fireRate = 0.85f;
    public float bulletForce = 20f;
    private float timer = 0;
    private float shootAnimTimer = 0;
    private float animLinger = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && timer >= fireRate) {
            Shoot();
            timer = 0;
            // Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        } else {
            timer += Time.deltaTime;
        }

        if (shootAnimTimer < animLinger)
        {
            shootAnimTimer += Time.deltaTime;

        } else {
            stopShootingAnim();
            shootAnimTimer = 0;
        }
        
    }

    void Shoot() {
        animator.SetBool("isShooting", true);
        Instantiate(bullet, Firepoint.position, Firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Firepoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void stopShootingAnim()
    {
        animator.SetBool("isShooting", false);

    }
}
