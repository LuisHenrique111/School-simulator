using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacasCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Artes_lvl1"){
            gameObject.SetActive(false);
        }else if(other.gameObject.tag == "Humanas_lvl1" ){
            gameObject.SetActive(false);
        }else if(other.gameObject.tag == "Engenharia_lvl1" ){
            gameObject.SetActive(false);
        }else if(other.gameObject.tag == "Medicina_lvl1" ){
            gameObject.SetActive(false);
        }
    }
}
