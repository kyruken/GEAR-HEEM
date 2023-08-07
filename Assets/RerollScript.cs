using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RerollScript : MonoBehaviour
{
    public int cost = 10;
    public GameObject text;
    public GameObject costText;
    private bool playerInRadius = false;
    public GameObject[] currentTotems;
    private PlayerExperienceScript playerExp;
    // Start is called before the first frame update
    void Start()
    {
        currentTotems = GameObject.FindGameObjectsWithTag("Totem");
        playerExp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerExperienceScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRadius) 
        {
            buyReroll();
        }
    }

    public void deleteCurrentTotems()
    {
        currentTotems = GameObject.FindGameObjectsWithTag("Totem");
        Debug.Log("deleting totem");
        foreach (GameObject totem in currentTotems)
        {
            Debug.Log("deleting totem");
            Destroy(totem);
        }
    }

    public void spawnNewTotems()
    {

    }


    private void buyReroll()
    {
         if (Input.GetButtonDown("Fire2") && playerExp.currentExp >= cost) 
        {
            deleteCurrentTotems();
            playerExp.currentExp -= cost;
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
}
