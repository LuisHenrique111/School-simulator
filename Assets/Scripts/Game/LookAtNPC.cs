using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtNPC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt( Camera.main.transform);
        this.transform.Rotate(0,180,0);
    }
}
