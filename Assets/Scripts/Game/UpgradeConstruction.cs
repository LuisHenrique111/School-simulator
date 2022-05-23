using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Data;
using Game.Variables;
using Game.Variables.Generic;

public class UpgradeConstruction : MonoBehaviour
{
    public GameObject original;
    public GameObject original2;
    public GameObject original3;
    public GameObject upgrade1;
    public GameObject upgrade2;
    public int currentCasa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        original = GameObject.Find("GeografiaLevel1(Clone)");


        original2 = GameObject.Find("MatematicaLevel1(Clone)");

        original3 = GameObject.Find("HistoriaLevel1(Clone)");

        
        
    }

    public void Upgrade(int index){
        GameController.Instance.building[index].nivel = GameController.Instance.building[index].nivel + 1;
        if(GameController.Instance.building[index].nivel == 2 && GameManager.Instance.coinManager.Value >= GameController.Instance.building[index].priceEvolution[index]){
            GameManager.Instance.DiminuirMoedas(GameController.Instance.building[index].priceEvolution[index]);
            if(index == 0){
                upgrade1 = Instantiate(GameController.Instance.building[index].evolutionAsset[0], original.transform.position, original.transform.rotation);
                Destroy(original);
            }
            if(index == 1){
                upgrade1 = Instantiate(GameController.Instance.building[index].evolutionAsset[0], original2.transform.position, original2.transform.rotation);
                Destroy(original2);
            }
            if(index == 2){
                upgrade1 = Instantiate(GameController.Instance.building[index].evolutionAsset[0], original3.transform.position, original3.transform.rotation);
                Destroy(original3);
            }
            
        }
        else if(GameController.Instance.building[index].nivel == 3 && GameManager.Instance.coinManager.Value >= GameController.Instance.building[index].priceEvolution[index]){
            GameManager.Instance.DiminuirMoedas(GameController.Instance.building[index].priceEvolution[index]);
            upgrade2 = Instantiate(GameController.Instance.building[index].evolutionAsset[1], upgrade1.transform.position, upgrade1.transform.rotation);
            Destroy(upgrade1);
        }
    }
}
