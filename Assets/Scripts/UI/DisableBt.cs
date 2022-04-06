using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableBt : MonoBehaviour
{
    public GameObject RefBt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RefBt.active)
        {
            this.GetComponent<Button>().interactable = false;
        }
        else
        {
            this.GetComponent<Button>().interactable = true;
        }
    }
}
