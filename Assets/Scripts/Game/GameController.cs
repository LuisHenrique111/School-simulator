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
    [Header("Vetor dos professores")]
    public TeacherData[] teachers;

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
    }

    // Update is called once per frame
    void Update()
    {
        
        seconds.Value = seconds.Value + Time.deltaTime;
        minutes.Value = (int)seconds.Value;
        
        if(seconds.Value >= 60){
            seconds.Value = 0;
            minutes.Value = 0;
            hours = hours + 1;
            profit();
        }

        TrocaDia();
        ControllerAlunos();
        GameOver();
    }

    public void profit(){
        for(int i = 0; i < teachers.Length; i++){
            if(teachers[i].contratado == true && ((hours % teachers[i].horaRentavel) == 0)){
                coin.Value = coin.Value + teachers[i].rendaHora;
            }
        }
    }

    public void TrocaDia(){
        if(hours == 10){
            seconds.Value = 0;
            minutes.Value = 0;
            hours = 0;
        }
    }

    public void ControllerAlunos(){
        if(GameManager.Instance.happiness.Value <= 30){
            GameManager.Instance.DiminuirEstudades(8);
        }
    }
    
    public void GameOver(){
        if(GameManager.Instance.studentsManager.Value <= 0){
            GameManager.Instance.SetEstudades(7);
            GameManager.Instance.SetFelicidade(50);
            GameManager.Instance.SetMoedas(500);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Win(){
        if(GameManager.Instance.studentsManager.Value >= 100 && GameManager.Instance.happiness.Value >= 80){
            GameManager.Instance.SetEstudades(7);
            GameManager.Instance.SetFelicidade(50);
            GameManager.Instance.SetMoedas(500);
            SceneManager.LoadScene("GameOver");
        }
    }

}
