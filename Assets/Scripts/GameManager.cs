using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Variables;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Variaveis globais")]
    public IntVariable happiness;
    public IntVariable coinManager;
    public IntVariable studentsManager;
    public IntVariable porcentagemGanho;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        SetEstudades(7);
        SetFelicidade(50);
        SetMoedas(100);
        porcentagemGanho.Value = 50;
        GameController.Instance.teachers[0].contratado = false;
        GameController.Instance.teachers[1].contratado = false;
        GameController.Instance.teachers[2].contratado = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GanhoFelicidade(int valueHappiness){
        happiness.Value = happiness.Value + valueHappiness;
    }

    public void PerdaFelicidade(int valueHappiness){
        happiness.Value = happiness.Value - valueHappiness;
    }

    public void AumentarMoedas(int valueCoin){
        happiness.Value = happiness.Value + valueCoin;
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
