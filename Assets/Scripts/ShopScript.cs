using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public int cost = 10;
    public string totemType;
    public GameObject text;
    public GameObject costText;
    public Animator animator;
    private PlayerHealthScript playerHealth;
    private PlayerScript playerSpeed;
    private PlayerScript playerAttackPower;
    private PlayerExperienceScript playerExp;
    private RerollScript reroll;
    private bool playerInRadius = false;
    private bool totemActivated = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        switch(totemType)
        {
            case "Health":
                playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();
                break;
            case "Speed":
                playerSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
                break;
            case "Attack":
                playerAttackPower = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
                break;                
            case "Range":
                playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();
                break;            
        }

        playerExp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerExperienceScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Constantly runs buyItem function, idk better solution
        if (playerInRadius && totemActivated) 
        {
            buyItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player") 
        {
            text.SetActive(true);
            costText.SetActive(true);
            playerInRadius = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            text.SetActive(false);
            costText.SetActive(false);
            playerInRadius = false;
        }         
    }

    private void buyItem()
    {
        if (Input.GetButtonDown("Fire2") && playerExp.currentExp >= cost) 
        {
            switch(totemType) {
                case "Health":
                    playerHealth.health += 1;
                    break;
                case "Speed":
                    playerSpeed.moveSpeed += 0.5f;
                    break;
                case "Attack":
                    playerAttackPower.playerAttackPower += 1;
                    break;
                case "Experience":
                    playerExp.expPlusGain += 1;
                    break;
                case "Range":
                    playerSpeed.moveSpeed += 1f;
                    break;
            }
            playerExp.currentExp -= cost;
            disableTotem();
        }
    }

    private void disableTotem()
    {
        totemActivated = false;
        animator.SetBool("isActivated", false);

    }
}
