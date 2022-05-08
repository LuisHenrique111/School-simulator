using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Data;
using Game.Variables;
using Game.Variables.Generic;

public class UpgradeConstruction : MonoBehaviour
{
    private GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNivel(){
         
    }

    public void Upgrade(int index){
        temp = GameObject.Find("casa 1");
        GameController.Instance.building[index].nivel = GameController.Instance.building[index].nivel + 1;
        if(GameController.Instance.building[index].nivel == 2 && GameManager.Instance.coinManager.Value >= GameController.Instance.building[index].priceEvolution[index]){
            GameManager.Instance.DiminuirMoedas(GameController.Instance.building[index].priceEvolution[index]);
            temp.GetComponent<MeshFilter>().mesh = GameController.Instance.building[index].evolutionAsset[index];
        }

    }
}
