using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Data;
using Game.Variables;
using Game.Variables.Generic;
using UI;

public class UpReitoria : MonoBehaviour
{
    public GameObject reitoriaOriginal;
    public GameObject reitoriaUpgrade1;
    public GameObject reitoriaUpgrade2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        reitoriaOriginal = GameObject.Find("ReitoriaLevel1(Clone)");
        reitoriaUpgrade1 = GameObject.Find("ReitoriaLevel2(Clone)");
    }

    public void Upgrade(int index){
        GameController.Instance.building[index].nivel = GameController.Instance.building[index].nivel + 1;
        Tween.Instance.CloseUpConst(index);
        if(GameController.Instance.building[index].nivel == 2 && GameManager.Instance.coinManager.Value >= GameController.Instance.building[index].priceEvolution[0]){
            GameManager.Instance.DiminuirMoedas(GameController.Instance.building[index].priceEvolution[0]);
            GameManager.Instance.GanhoFelicidade(5);
            if(index == 0){
                reitoriaUpgrade1 = Instantiate(GameController.Instance.building[index].evolutionAsset[0], reitoriaOriginal.transform.position, reitoriaOriginal.transform.rotation);
                Destroy(reitoriaOriginal);
            }
        }else if(GameController.Instance.building[index].nivel == 3 && GameManager.Instance.coinManager.Value >= GameController.Instance.building[index].priceEvolution[1]){
            GameManager.Instance.GanhoFelicidade(10);
            GameManager.Instance.DiminuirMoedas(GameController.Instance.building[index].priceEvolution[1]);
            if(index == 0){
                reitoriaUpgrade2 = Instantiate(GameController.Instance.building[index].evolutionAsset[1], reitoriaUpgrade1.transform.position, reitoriaUpgrade1.transform.rotation);
                Destroy(reitoriaUpgrade1);
            }
            
        }
    }
}
