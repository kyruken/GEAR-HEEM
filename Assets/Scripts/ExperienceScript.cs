using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceScript : MonoBehaviour
{
    private PlayerExperienceScript playerExp;
    // Start is called before the first frame update
    void Start()
    {
        playerExp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerExperienceScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            playerExp.gainExp(1);
        }
    }
}
