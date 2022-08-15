using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Data;
using Game.Variables;
using Game.Variables.Generic;
using UI;

public class UpConstruction : MonoBehaviour
{
    public GameObject reitoriaOriginal;
    GameObject reitoriaUpgrade1;
    GameObject reitoriaUpgrade2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Verifica se esta na cena o objeto
        if(GameController.Instance.building[0].spawned == true){
            reitoriaOriginal = GameObject.Find("ReitoriaLevel1");
            if(GameManager.Instance.newGame.Value == false){
                GameObject.DontDestroyOnLoad(reitoriaOriginal);
            }
        }
    }

    public void Upgrade(int index){
        GameController.Instance.building[index].nivel = GameController.Instance.building[index].nivel + 1;
        Tween.Instance.CloseUpConst(index);
        if(GameController.Instance.building[index].nivel == 2 && GameManager.Instance.coinManager.Value >= GameController.Instance.building[index].priceEvolution[0]){
            GameManager.Instance.DiminuirMoedas(GameController.Instance.building[index].priceEvolution[0]);
            GameManager.Instance.GanhoFelicidade(5);
            if(index == 0){
                reitoriaUpgrade1 = Instantiate(GameController.Instance.building[index].evolutionAsset[0], reitoriaOriginal.transform.position, reitoriaOriginal.transform.rotation);
                if(GameManager.Instance.newGame.Value == false){
                    GameObject.DontDestroyOnLoad(reitoriaUpgrade1);
                }
                Destroy(reitoriaOriginal);
            }
        }else if(GameController.Instance.building[index].nivel == 3 && GameManager.Instance.coinManager.Value >= GameController.Instance.building[index].priceEvolution[1]){
            GameManager.Instance.GanhoFelicidade(10);
            GameManager.Instance.DiminuirMoedas(GameController.Instance.building[index].priceEvolution[1]);
            if(index == 0){
                reitoriaUpgrade2 = Instantiate(GameController.Instance.building[index].evolutionAsset[1], reitoriaUpgrade1.transform.position, reitoriaUpgrade1.transform.rotation);
                if(GameManager.Instance.newGame.Value == false){
                    GameObject.DontDestroyOnLoad(reitoriaUpgrade2);
                }
                Destroy(reitoriaUpgrade1);
            }
            
        }
    }
}
