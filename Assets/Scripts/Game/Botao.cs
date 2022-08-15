using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

public class Botao : MonoBehaviour
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
            /*if(Input.GetMouseButtonDown(0)){
                Tween.Instance.OpenProfMenu();
            }*/
            if(Input.GetMouseButtonDown(0)){
                Tween.Instance.OpenUpgrade(0);           
            }
        }
    }

    void OnMouseEnter(){
        mouseDentroDoObjeto = true;
    }

    void OnMouseExit(){
        mouseDentroDoObjeto = false;
    }
}
