using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Variables;
using Game.Variables.Generic;

public class NPC : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Fim"){
            SpawnNPC.Instance.contador--;
            Destroy(gameObject);
        }
    }

}
