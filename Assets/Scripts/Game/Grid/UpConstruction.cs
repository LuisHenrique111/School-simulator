using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

public class UpConstruction : MonoBehaviour
{
    public GameObject auxEvolution1;
    public GameObject auxEvolution2;

    public string auxName;

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
        if(GameController.Instance.predios[UIVariables.Instance.currentPredio].nivel == 2){
            currentEvolution = 1;
            if(UIVariables.Instance.currentPredio == 0){
                auxEvolution1 = GameObject.Find("artes_cenicas_lv1(Clone)");
            }
            if(UIVariables.Instance.currentPredio == 1){
                auxEvolution1 = GameObject.Find("engenharia_level_01(Clone)");
            }
            if(UIVariables.Instance.currentPredio == 2){
                auxEvolution1 = GameObject.Find("humanas_lv1(Clone)");
            }
            if(UIVariables.Instance.currentPredio == 3){
                auxEvolution1 = GameObject.Find("medNvl1(Clone)");
            }
            Instantiate(GameController.Instance.predios[UIVariables.Instance.currentPredio].evolutionAsset[0], auxEvolution1.transform.position, auxEvolution1.transform.rotation);
            GameManager.Instance.DiminuirMoedas(GameController.Instance.predios[UIVariables.Instance.currentConst].priceEvolution[0]);
            Destroy(auxEvolution1);
        }
        else if(GameController.Instance.predios[UIVariables.Instance.currentPredio].nivel == 3){
            if(UIVariables.Instance.currentPredio == 0){
                auxEvolution2 = GameObject.Find("artes_cenicas_lv2(Clone)");
            }
            if(UIVariables.Instance.currentPredio == 1){
                auxEvolution2 = GameObject.Find("engenharia_level_02(Clone)");
            }
            if(UIVariables.Instance.currentPredio == 2){
                auxEvolution2 = GameObject.Find("humanas_lv2(Clone)");
            }
            if(UIVariables.Instance.currentPredio == 3){
                auxEvolution2 = GameObject.Find("medNvl2(Clone)");
            }
            currentEvolution = 2;
            Instantiate(GameController.Instance.predios[UIVariables.Instance.currentPredio].evolutionAsset[1], auxEvolution2.transform.position, auxEvolution2.transform.rotation);
            GameManager.Instance.DiminuirMoedas(GameController.Instance.predios[UIVariables.Instance.currentConst].priceEvolution[1]);
            Destroy(auxEvolution2);
        }
    }
}
