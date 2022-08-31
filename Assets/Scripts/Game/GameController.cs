using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Data;
using Game.Variables;
using Game.Variables.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [Header("Vetor dos predios")]
    public BuildingData[] building;
    public BuildingData[] predios;

    [Header("Vetor dos slots")]
    public GameObject[] slots;

    [Header("Variaveis globais")] 
    #region variaveis globais 
    public FloatVariable seconds;
    public int hours;
    public IntVariable minutes;
    public IntVariable coin;
    #endregion

    public GameObject telaGameOver;

    
    

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        NewGame();
    }

    // Update is called once per frame
    void Update()
    {
        liberaPlacas();
        Win();
        GameOver();
    }

    public void ControllerAlunos(){
        if(GameManager.Instance.happiness.Value <= 30){
            GameManager.Instance.DiminuirEstudades(8);
        }
    }
    
    public void GameOver(){
        if(GameManager.Instance.studentsManager.Value < 0){
            GameManager.Instance.SetEstudades(0);
            GameManager.Instance.SetFelicidade(50);
            GameManager.Instance.SetMoedas(900);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Win(){
        if(GameManager.Instance.studentsManager.Value >= 100 && GameManager.Instance.happiness.Value >= 80){
            GameManager.Instance.SetEstudades(0);
            GameManager.Instance.SetFelicidade(50);
            GameManager.Instance.SetMoedas(900);
            SceneManager.LoadScene("Win");
        }
    }

    public void liberaPlacas(){
        if(building[0].nivel == 2){
            slots[2].GetComponent<Renderer>().material.color = Color.cyan;
            slots[2].GetComponent<BotaoPlacas>().enabled = true;
        }
        if(building[0].nivel == 3){
            slots[3].GetComponent<Renderer>().material.color = Color.cyan;
            slots[3].GetComponent<BotaoPlacas>().enabled = true;
        }
    }

    public void NewGame(){
        if(GameManager.Instance.newGame.Value == true){
            GameManager.Instance.SetEstudades(0);
            GameManager.Instance.SetFelicidade(50);
            GameManager.Instance.SetMoedas(1000);
            building[0].nivel = 1;
            for(int i = 0; i<predios.Length; i++){
                
                predios[i].spawned = false;
            }
            if(building[0].nivel == 1){
                GameObject obj = GameObject.Find("ReitoriaLevel2(Clone)");
                GameObject obj2 = GameObject.Find("ReitoriaLevel3(Clone)");
                Destroy(obj);
                Destroy(obj2);
            }
            GameManager.Instance.newGame.Value = false;
        }
    }
}
