using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Data;
using Game.Variables;
using Game.Variables.Generic;
using UI;

public class UpgradeConstruction : MonoBehaviour
{
    public static UpgradeConstruction Instance;
    public GameObject original;
    public GameObject original2;
    public GameObject original3;
    public GameObject upgrade1;
    public GameObject upgrade2;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.Instance.building[0].spawned == true){
            original = GameObject.Find("MatematicaLevel1(Clone)");
            if(GameManager.Instance.newGame.Value == false){
                GameObject.DontDestroyOnLoad(original);
            }
        }
        if(GameController.Instance.building[1].spawned == true){
            original2 = GameObject.Find("GeografiaLevel1(Clone)");
            if(GameManager.Instance.newGame.Value == false){
                GameObject.DontDestroyOnLoad(original2);
            }
        }
        if(GameController.Instance.building[2].spawned == true){
            original3 = GameObject.Find("HistoriaLevel1(Clone)");
            if(GameManager.Instance.newGame.Value == false){
                GameObject.DontDestroyOnLoad(original3);
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
                upgrade1 = Instantiate(GameController.Instance.building[index].evolutionAsset[0], original.transform.position, original.transform.rotation);
                if(GameManager.Instance.newGame.Value == false){
                    GameObject.DontDestroyOnLoad(upgrade1);
                }
                Destroy(original);
            }
            if(index == 1){
                upgrade1 = Instantiate(GameController.Instance.building[index].evolutionAsset[0], original2.transform.position, original2.transform.rotation);
                if(GameManager.Instance.newGame.Value == false){
                    GameObject.DontDestroyOnLoad(upgrade1);
                }
                Destroy(original2);
            }
            if(index == 2){
                upgrade1 = Instantiate(GameController.Instance.building[index].evolutionAsset[0], original3.transform.position, original3.transform.rotation);
                if(GameManager.Instance.newGame.Value == false){
                    GameObject.DontDestroyOnLoad(upgrade1);
                }
                Destroy(original3);
            }
        }
        else if(GameController.Instance.building[index].nivel == 3 && GameManager.Instance.coinManager.Value >= GameController.Instance.building[index].priceEvolution[1]){
            GameManager.Instance.GanhoFelicidade(10);
            GameManager.Instance.DiminuirMoedas(GameController.Instance.building[index].priceEvolution[1]);
            upgrade2 = Instantiate(GameController.Instance.building[index].evolutionAsset[1], upgrade1.transform.position, upgrade1.transform.rotation);
            if(GameManager.Instance.newGame.Value == false){
                GameObject.DontDestroyOnLoad(upgrade2);
            }
            Destroy(upgrade1);
        }
    }
}
