using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public Text playerHealthText;
    public Text playerExpText;
    public Text gameTimerText;
    public float timer;
    public GameObject winScreen;
    private PlayerHealthScript playerHealth;
    private PlayerExperienceScript playerExp;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();
        playerExp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerExperienceScript>();
        gameTimerText.text = timer.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
        }
        playerHealthText.text = playerHealth.health.ToString();
        playerExpText.text = playerExp.currentExp.ToString();
        gameTimerText.text = Mathf.Round(timer).ToString();
        if (timer <= 0) {
            winGame();
        }
        
    }

    private void winGame() {
        winScreen.SetActive(true);
    }
}
