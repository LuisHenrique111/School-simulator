using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;


public class BotaoPlacas : MonoBehaviour
{
    bool mouseDentroDoObjeto;

    public static BotaoPlacas Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        mouseDentroDoObjeto = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(mouseDentroDoObjeto == true){
            if(Input.GetMouseButtonDown(0)){
                Tween.Instance.OpenProfMenu();
                UIVariables.Instance.position = gameObject.transform.position;
                UIVariables.Instance.rotation = gameObject.transform.rotation;
            }
        }
    }

    /*public void GridSpawn(int index){
        Instantiate(GameController.Instance.building[index].asset, slot.transform.position, slot.transform.rotation);
    }*/

    

    public void OnMouseEnter(){
        mouseDentroDoObjeto = true;
        
    }

    void OnMouseExit(){
        mouseDentroDoObjeto = false;
    }
}

