using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid : MonoBehaviour
{
    public Transform cubo;
    public GameObject casa;
    void Start()
    {
        
    }

    
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Mouse0)){
        Instantiate(casa,cubo.position,cubo.rotation); 
       } 
    }
}
