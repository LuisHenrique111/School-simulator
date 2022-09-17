using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

public class UpConstruction : MonoBehaviour
{
    GameObject auxEvolution1;

    public int currentEvolution;

    public static UpConstruction Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeConstrucao(){
        GameController.Instance.predios[UIVariables.Instance.currentPredio].nivel = GameController.Instance.predios[UIVariables.Instance.currentPredio].nivel +1;
        Tween.Instance.CloseUpConstrucao();
        if(GameController.Instance.predios[UIVariables.Instance.currentPredio].nivel == 2 && GameManager.Instance.coinManager.Value >= GameController.Instance.predios[UIVariables.Instance.currentPredio].priceEvolution[0]){
            auxEvolution1 = GameObject.Find("engenharia_level_01(Clone)");
            currentEvolution = 1;
            Instantiate(GameController.Instance.predios[UIVariables.Instance.currentPredio].evolutionAsset[0], auxEvolution1.transform.position, auxEvolution1.transform.rotation);
            GameManager.Instance.DiminuirMoedas(GameController.Instance.predios[UIVariables.Instance.currentConst].priceEvolution[0]);
            Destroy(auxEvolution1);
        }
        else if(GameController.Instance.predios[UIVariables.Instance.currentPredio].nivel == 3 && GameManager.Instance.coinManager.Value >= GameController.Instance.predios[UIVariables.Instance.currentPredio].priceEvolution[1]){
            auxEvolution1 = GameObject.Find("engenharia_level_02(Clone)");
            currentEvolution = 2;
            Instantiate(GameController.Instance.predios[UIVariables.Instance.currentPredio].evolutionAsset[0], auxEvolution1.transform.position, auxEvolution1.transform.rotation);
            GameManager.Instance.DiminuirMoedas(GameController.Instance.predios[UIVariables.Instance.currentConst].priceEvolution[0]);
            Destroy(auxEvolution1);
        }
    }
}
