using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationDestination : MonoBehaviour
{
    //public LayerMask floorLayer;
    [HideInInspector]
    public Vector3 destination;

    bool alreadyCollided=false;
    private void OnCollisionEnter(Collision collision)
    {
        
        if(!alreadyCollided)
        {
            alreadyCollided = true;
            if (collision.gameObject.layer == 3)
            {
                destination = collision.contacts[0].point;
            }
        }



    }

}
