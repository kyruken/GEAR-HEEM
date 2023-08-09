using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RerollScript : MonoBehaviour
{
    public int cost = 10;
    public GameObject text;
    public GameObject costText;
    private bool playerInRadius = false;
    public GameObject[] newTotems;
    public GameObject[] currentTotems;
    private PlayerExperienceScript playerExp;
    private float spawnBoundX1 = -7.3f;
    private float spawnBoundY1 = 3.77f;

    private float spawnBoundX2 = 9.24f;
    private float spawnBoundY2 = -1.46f;
    // Start is called before the first frame update
    void Start()
    {
        currentTotems = GameObject.FindGameObjectsWithTag("Totem");
        playerExp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerExperienceScript>();
        spawnNewTotems();
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
            Destroy(totem);
        }
    }

    public void spawnNewTotems()
    {
        int randomTotemSpawn = Random.Range(4, 8);
        for (int totemSpawnCount = 0; totemSpawnCount < randomTotemSpawn; totemSpawnCount++)
        {
            float randomLocationX = Random.Range(spawnBoundX1, spawnBoundX2);
            float randomLocationY = Random.Range(spawnBoundY1, spawnBoundY2);
            int randomTotemNumber = Random.Range(0, 5);
            Instantiate(newTotems[randomTotemNumber], new Vector3(randomLocationX, randomLocationY, 0), Quaternion.identity);

        }


    }


    private void buyReroll()
    {
         if (Input.GetButtonDown("Fire2") && playerExp.currentExp >= cost) 
        {
            deleteCurrentTotems();
            playerExp.currentExp -= cost;
            spawnNewTotems();
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
