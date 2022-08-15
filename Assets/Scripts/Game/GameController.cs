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
        if(GameManager.Instance.newGame.Value == true){
            GameManager.Instance.SetEstudades(0);
            GameManager.Instance.SetFelicidade(50);
            GameManager.Instance.SetMoedas(900);
            for(int i = 0; i<building.Length; i++){
                building[i].nivel = 1;
                building[i].spawned = false;
            }
            GameManager.Instance.newGame.Value = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

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

}
