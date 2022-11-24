using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

public class BotaoUpPredios : MonoBehaviour
{
    bool mouseDentroDoObjeto;
    public int currentPredio;
    public static BotaoUpPredios Instance;
    // Start is called before the first frame update
    void Start()
    {
        mouseDentroDoObjeto = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(mouseDentroDoObjeto == true){
            if(Input.GetMouseButtonDown(0)){
                
                if(gameObject.tag == "Artes_lvl1"){
                    UIVariables.Instance.currentPredio = 0;
                }
                if(gameObject.tag == "Artes_lvl2"){
                    UIVariables.Instance.currentPredio = 0;
                }
                if(gameObject.tag == "Artes_lvl3"){
                    UIVariables.Instance.currentPredio = 0;
                }
                if(gameObject.tag == "Engenharia_lvl1"){
                    UIVariables.Instance.currentPredio = 1;
                }
                if(gameObject.tag == "Engenharia_lvl2"){
                    UIVariables.Instance.currentPredio = 1;
                }
                if(gameObject.tag == "Engenharia_lvl3"){
                    UIVariables.Instance.currentPredio = 1;
                }
                if(gameObject.tag == "Humanas_lvl1"){
                    UIVariables.Instance.currentPredio = 2;
                }
                if(gameObject.tag == "Humanas_lvl2"){
                    UIVariables.Instance.currentPredio = 2;
                }
                if(gameObject.tag == "Humanas_lvl3"){
                    UIVariables.Instance.currentPredio = 2;
                }
                if(gameObject.tag == "Medicina_lvl1"){
                    UIVariables.Instance.currentPredio = 3;
                }
                if(gameObject.tag == "Medicina_lvl2"){
                    UIVariables.Instance.currentPredio = 3;
                }
                if(gameObject.tag == "Medicina_lvl3"){
                    UIVariables.Instance.currentPredio = 3;
                }
                Tween.Instance.OpenUpConstrucao();
            }
        }
    }

    void OnMouseEnter(){
        mouseDentroDoObjeto = true;
        
        Debug.Log(currentPredio);
    }

    void OnMouseExit(){
        mouseDentroDoObjeto = false;
    }
}
