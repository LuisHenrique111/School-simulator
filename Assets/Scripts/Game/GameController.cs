using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Data;
using Game.Variables;
using Game.Variables.Generic;
using UnityEngine.SceneManagement;
using UI;
using UnityEngine.UI;
using System.IO;
using System;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [Header("Vetor dos predios")]
    public BuildingData[] predios;

    [Header("Vetor dos predios")]
    public BuildingData[] building;

    [Header("Vetor dos slots")]
    public GameObject[] slots;

    [Header("Vetor dos NPCs")]
    public GameObject[] npc;

    [Header("Vetor Sprite happiness")]
    public Sprite[] spriteHappiness;

    [Header("Variaveis globais")] 
    #region variaveis globais
    public Image happinessGeneral;
    public int  averageHappiness = 50, happinessAdd;
    
    public IntVariable coin;
    #endregion

    public GameObject waypointPredio2;
    public GameObject waypointPredio3;
    public GameObject content,prefabBirdder;

    public GameObject telaName;

    public BoolVariable save;

    
    

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        if(GameManager.Instance.newGame.Value == true){
            UIVariables.Instance.collegeName.Value = " ";
            Tween.Instance.NameCollege();
            GameManager.Instance.SetEstudades(0);
            GameManager.Instance.save.Value = false;
            File.Delete(Application.persistentDataPath + "/saveGame.txt");
            GameManager.Instance.SetFelicidade(50);
            GameManager.Instance.SetMoedas(900);
            building[0].nivel = 1;
            Time.timeScale = 0f;
            for(int i = 0; i<predios.Length; i++){
                predios[i].nivel = 1;
                predios[i].spawned = false;
            }
            GameManager.Instance.newGame.Value = false;
        }else{
            SaveControler.Load();
            telaName.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        averageHappiness = Mathf.Clamp(averageHappiness,0,60);
        liberaPlacas();
        Win();
        GameOver();
        ControlHappiness();
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
            GameManager.Instance.save.Value = false;
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
            waypointPredio2.SetActive(true);
        }
        if(building[0].nivel == 3){
            slots[3].GetComponent<Renderer>().material.color = Color.cyan;
            slots[3].GetComponent<BotaoPlacas>().enabled = true;
            waypointPredio3.SetActive(true);
        }
    }

    public void ControlHappiness()
    {
        npc = GameObject.FindGameObjectsWithTag("NPC");

        foreach (var item in npc)
        {
            happinessAdd += item.GetComponent<NPC_control>().individualHappiness;
        }

        if(npc.Length <= 0)
        {

        }
        else
        {
            averageHappiness = happinessAdd/npc.Length;
            GameManager.Instance.SetFelicidade(averageHappiness);
            happinessAdd = 0;
        }
        

        if(averageHappiness < 50)
        {
            happinessGeneral.sprite = spriteHappiness[0];
        }
        else if(averageHappiness >= 50 && averageHappiness < 60)
        {
            happinessGeneral.sprite = spriteHappiness[1];
        }
        else if(averageHappiness >= 60 && averageHappiness < 80)
        {
            happinessGeneral.sprite = spriteHappiness[2];
        }
        else
        {
            happinessGeneral.sprite = spriteHappiness[3];
        }

    }

    public void AceleraTempo(){
        Time.timeScale = 2.0f;
    }

    public void Play(){
        Time.timeScale = 1.0f;
    }

    public void Pause(){
        Time.timeScale = 0.0f;
    }
}
