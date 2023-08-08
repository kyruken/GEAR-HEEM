using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeScript : MonoBehaviour
{
    public Transform Firepoint;
    public Animator animator;
    public GameObject swordHitbox;
    public float fireRate = 1f;
    private float timer = 0;
    private float swordAnimTimer = 0;
    private float animLinger = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3") && timer >= fireRate) {
            Swing();
            // Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        } 
        else 
        {
            timer += Time.deltaTime;
        }
        if (swordAnimTimer < animLinger)
        {
            swordAnimTimer += Time.deltaTime;

        } else {
            stopSwordingAnim();
            swordAnimTimer = 0;
        }
    }

    void Swing() 
    {
        Debug.Log("Swording");
        animator.SetBool("isSwording", true);
        Instantiate(swordHitbox, Firepoint.position, Firepoint.rotation);
    }

    void stopSwordingAnim()
    {
        animator.SetBool("isSwording", false);

    }
}
