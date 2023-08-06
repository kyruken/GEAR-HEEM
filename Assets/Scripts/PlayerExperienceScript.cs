using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperienceScript : MonoBehaviour
{
    public int currentExp = 0;
    public int expPlusGain = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void gainExp(int expPoints)
    {
        currentExp += expPoints + expPlusGain;
    }
}
