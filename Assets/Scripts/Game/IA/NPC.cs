using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Variables;
using Game.Variables.Generic;

public class NPC : MonoBehaviour
{
    public static NPC instance;
    // put the points from unity interface
    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.tag == "Fim"){
            SpawnNPC.Instance.contador--;
            Destroy(gameObject);
        }
    }    
}
