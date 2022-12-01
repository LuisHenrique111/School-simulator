using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_control : MonoBehaviour
{
    public Sprite [] happiness;
    public Image happinessStatus;
    public TextMeshProUGUI nameNPC;
    public int individualHappiness = 50;    
   
    void Start()
    {
        nameNPC.text = Reader.instance.GenerateName();  
    }

    void FixedUpdate()
    {
        if(individualHappiness <= 20  )
        {
           
        }
        else if(individualHappiness < 30)
        {
            happinessStatus.sprite = happiness[0];
        }
        else if(individualHappiness >= 30 && individualHappiness < 50)
        {
            happinessStatus.sprite = happiness[1];
        }
        else if(individualHappiness >= 50 && individualHappiness < 60)
        {
            happinessStatus.sprite = happiness[2];
        }
        else if(individualHappiness >= 60 && individualHappiness < 80)
        {
            happinessStatus.sprite = happiness[3];
        }
        else
        {
            happinessStatus.sprite = happiness[4];
        }
    }
}
