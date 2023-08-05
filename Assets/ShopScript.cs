using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public int cost = 10;
    public GameObject text;
    public PlayerHealthScript playerHealth;
    public PlayerExperienceScript playerExp;
    private bool playerInRadius = false;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();
        playerExp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerExperienceScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Constantly runs buyItem function, idk better solution
        if (playerInRadius) 
        {
            buyItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player") 
        {
            text.SetActive(true);
            playerInRadius = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            text.SetActive(false);
        }         
    }

    private void buyItem()
    {
        if (Input.GetButtonDown("Fire2") && playerExp.currentExp >= cost) 
        {
            playerHealth.health += 1;
            playerExp.currentExp -= cost;
        }
    }
}
