using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

public class Grid : MonoBehaviour
{
    bool mouseDentroDoObjeto;
    // Start is called before the first frame update
    void Start()
    {
        mouseDentroDoObjeto = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(mouseDentroDoObjeto == true){
            if(Input.GetMouseButtonDown(1)){
                Tween.Instance.OpenProfMenu();
            }
        }
    }

    /*public void GridSpawn(int index){
        Instantiate(GameController.Instance.building[index].asset, slot.transform.position, slot.transform.rotation);
    }*/

    

    void OnMouseEnter(){
        mouseDentroDoObjeto = true;
    }

    void OnMouseExit(){
        mouseDentroDoObjeto = false;
    }
}
