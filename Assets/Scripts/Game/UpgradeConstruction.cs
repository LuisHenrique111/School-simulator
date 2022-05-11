using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Data;
using Game.Variables;
using Game.Variables.Generic;

public class UpgradeConstruction : MonoBehaviour
{
    public GameObject original;
    public GameObject upgrade1;
    public GameObject upgrade2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        original = GameObject.Find("casa 1(Clone)");
    }

    public void SetNivel(){
         
    }

    public void Upgrade(int index){
        GameController.Instance.building[index].nivel = GameController.Instance.building[index].nivel + 1;
        if(GameController.Instance.building[index].nivel == 2 && GameManager.Instance.coinManager.Value >= GameController.Instance.building[index].priceEvolution[index]){
            GameManager.Instance.DiminuirMoedas(GameController.Instance.building[index].priceEvolution[index]);
            upgrade1 = Instantiate(GameController.Instance.building[index].evolutionAsset[0], original.transform.position, original.transform.rotation);
            Destroy(original);
        }
        else if(GameController.Instance.building[index].nivel == 3 && GameManager.Instance.coinManager.Value >= GameController.Instance.building[index].priceEvolution[index]){
            
            GameManager.Instance.DiminuirMoedas(GameController.Instance.building[index].priceEvolution[index]);
            upgrade2 = Instantiate(GameController.Instance.building[index].evolutionAsset[1], upgrade1.transform.position, upgrade1.transform.rotation);
            Destroy(upgrade1);
        }
        
        

    }

    
}
