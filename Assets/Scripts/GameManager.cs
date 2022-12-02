using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Variables;
using Game.Data;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Variaveis globais")]
    public IntVariable happiness;
    public IntVariable coinManager;
    public IntVariable studentsManager;
    public BoolVariable newGame;
    public BoolVariable save;


    [Header("botao Continuar")]
    public Button Continue;
    public Button VoltaJogo;
    public bool IsMenu;
    public bool fileExists;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        
        if(File.Exists(Application.persistentDataPath + "/saveGame.txt")){
            Debug.Log("Existe");
            fileExists = true;
            save.Value = true;
        }else{
            fileExists = false;
            save.Value = false;
            Debug.Log("nao existe");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(IsMenu){

            if(save.Value == true ){
                Continue.interactable = true;
                VoltaJogo.interactable = true;
            }else{
                Continue.interactable = false;
                VoltaJogo.interactable = false;
            }
        }
        
        
    }

    public void GanhoFelicidade(int valueHappiness){
        happiness.Value = happiness.Value + valueHappiness;
    }

    public void PerdaFelicidade(int valueHappiness){
        happiness.Value = happiness.Value - valueHappiness;
    }

    public void AumentarMoedas(int valueCoin){
        coinManager.Value = coinManager.Value + valueCoin;
    }

    public void DiminuirMoedas(int valueCoin){
        coinManager.Value = coinManager.Value - valueCoin;
    }

    public void IncrementarEstudantes(int valueStudents){
        studentsManager.Value = studentsManager.Value + valueStudents;
    }

    public void DiminuirEstudades(int valueStudents){
        studentsManager.Value = studentsManager.Value - valueStudents;
    }

    public void SetEstudades(int valor){
        studentsManager.Value = valor;
    }

    public void SetMoedas(int valor){
        coinManager.Value = valor;
    }

    public void SetFelicidade(int valor){
        happiness.Value = valor;
    }
}
