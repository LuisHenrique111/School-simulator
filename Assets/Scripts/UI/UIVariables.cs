using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Variables;
using TMPro;
using UnityEngine.SceneManagement;
using System;


namespace UI{
    public class UIVariables : MonoBehaviour
    {
        public static UIVariables Instance;
        public Tween tween;
        public Vector3 position;
        public Quaternion rotation;

        #region variaveis globais
        [Header("Variaveis globais")]        
        public IntVariable coin;
        public IntVariable happiness;
        public IntVariable students;
        public IntVariable hours;
        public FloatVariable minutes;
        #endregion

        [Header("UI consumiveis")]
        #region consumiveis        
        public TMP_Text textCoin;
        public TMP_Text textHappiness;
        public TMP_Text textStudents;
        public TMP_Text textHours;
        public TMP_Text textMinutes;
        #endregion

        #region store teacher
        [Header("UI professor store")]
        public TMP_Text descricaoBuilding;
        public TMP_Text salario;
        public Image imagemProfessor;
        public TMP_Text nameTeacher;
        public Button btnContratado;
        public int currentConst;
        #endregion

        #region store Upgrade reitoria
        [Header("store Upgrade reitoria")]
        public TMP_Text[] precoUpgrade;
        public TMP_Text[] nivel;
        public Image[] imagemUpgrade;
        public Button[] btnUpgrade;
        #endregion

        #region store Upgrade predios
        [Header("store Upgrade predios")]
        public TMP_Text precoUpgradePredios;
        public TMP_Text nivelPredios;
        public Image imagemUpgradePredios;
        public Button btnUpgradePredios;
        public int currentPredio;
        #endregion


        [Header("telas")]
        public GameObject screenInsufficientMoney;
        public bool isGame;
        public bool isSalaDiretor;

        public StringVariable collegeName;
        public TMP_Text nameCollege;
        int minutesAux;

        public BoolVariable tutorialActive;

        

        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
        }

        // Update is called once per frame
        void Update()
        {
            if(isGame){
                minutes.Value += Time.deltaTime;
                minutesAux = Convert.ToInt32(minutes.Value);
                if(minutes.Value>=60){
                    hours.Value++;
                    minutes.Value = 0;
                }
                if(hours.Value>=60){
                    hours.Value = 0;
                }
                textCoin.text = coin.Value.ToString();
                textHappiness.text = happiness.Value.ToString();
                textStudents.text = students.Value.ToString();
                textMinutes.text = minutesAux.ToString();
                textHours.text = hours.Value.ToString();
                nameCollege.text = collegeName.Value.ToString();
                VerificaBotaoCompra();       
            }
            
        }

       /* public void VerificaBotaoUpgrade(){
            if(coin.Value >= GameController.Instance.building[0].priceEvolution[0]){
                btnUpgrade[0].interactable = true;
            }else{
                btnUpgrade[0].interactable = false;
            }
            if(coin.Value >= GameController.Instance.building[1].priceEvolution[0]){
                btnUpgrade[1].interactable = true;
            }else{
                btnUpgrade[1].interactable = false;
            }
            if(coin.Value >= GameController.Instance.building[2].priceEvolution[0]){
                btnUpgrade[2].interactable = true;
            }else{
                btnUpgrade[2].interactable = false;
            }
        }*/

        public void VerificaBotaoCompra(){
            if(GameController.Instance.predios[currentConst].spawned == true){
                btnContratado.interactable = false;
            }else{
                btnContratado.interactable = true;
            }
        }

        public void NextProf(){
            currentConst = (currentConst + 1) % GameController.Instance.predios.Length;
            salario.text = GameController.Instance.predios[currentConst].price.ToString();
            imagemProfessor.sprite = GameController.Instance.predios[currentConst].UISpriteBuilding;
            nameTeacher.text = GameController.Instance.predios[currentConst].nameBuilding;
            descricaoBuilding.text = GameController.Instance.predios[currentConst].descricaoBuilding;
            

        }

        public void PrevProf(){
            currentConst--;
            salario.text = GameController.Instance.predios[currentConst].price.ToString();
            imagemProfessor.sprite = GameController.Instance.predios[currentConst].UISpriteBuilding;
            nameTeacher.text = GameController.Instance.predios[currentConst].nameBuilding;
            descricaoBuilding.text = GameController.Instance.predios[currentConst].descricaoBuilding;
           
            
            if (currentConst < 0)
            {
                currentConst += GameController.Instance.predios.Length;
            }
        }

        public void InfoUpgradePredios(int i){
            precoUpgradePredios.text = GameController.Instance.predios[currentPredio].priceEvolution[i].ToString();
            nivelPredios.text = GameController.Instance.predios[currentPredio].nivel.ToString();
            imagemUpgradePredios.sprite = GameController.Instance.predios[currentPredio].UISpriteBuilding;

        }

        public void BtnCompraUpgrade(){
            
            if( GameController.Instance.predios[UIVariables.Instance.currentPredio].nivel == 1){
                if(coin.Value >= GameController.Instance.predios[currentPredio].priceEvolution[0])
                {
                   if(GameController.Instance.predios[UIVariables.Instance.currentPredio].nameBuilding == "Artes cenicas")
                   {
                        Instantiate(GameController.Instance.prefabBirdder,GameController.Instance.content.transform);
                        Birdder.instance.textMessage.text = Reader.instance.ArtesMsg();
                   }
                   else if(GameController.Instance.predios[UIVariables.Instance.currentPredio].nameBuilding == "Engenharia")
                   {
                        Instantiate(GameController.Instance.prefabBirdder,GameController.Instance.content.transform);
                        Birdder.instance.textMessage.text = Reader.instance.EngenhariaMsg();
                   }
                   else if(GameController.Instance.predios[UIVariables.Instance.currentPredio].nameBuilding == "Humanas")
                   {
                        Instantiate(GameController.Instance.prefabBirdder,GameController.Instance.content.transform);
                        Birdder.instance.textMessage.text = Reader.instance.HumanasMsg();
                   }
                   else if(GameController.Instance.predios[UIVariables.Instance.currentPredio].nameBuilding == "Medicina")
                   {
                        Instantiate(GameController.Instance.prefabBirdder,GameController.Instance.content.transform);
                        Birdder.instance.textMessage.text = Reader.instance.MedicinaMsg();
                   }
                    UpConstruction.Instance.UpgradeConstrucao();
                    tween.CloseUpConstrucao();
                }else{
                    screenInsufficientMoney.SetActive(true);
                    tween.ErroCompUp();
                }
            }
            else if( GameController.Instance.predios[UIVariables.Instance.currentPredio].nivel == 2){
                if(coin.Value >= GameController.Instance.predios[currentPredio].priceEvolution[0]){
                    if(GameController.Instance.predios[UIVariables.Instance.currentPredio].nameBuilding == "Artes cenicas")
                   {
                        Instantiate(GameController.Instance.prefabBirdder,GameController.Instance.content.transform);
                        Birdder.instance.textMessage.text = Reader.instance.ArtesMsg();
                   }
                   else if(GameController.Instance.predios[UIVariables.Instance.currentPredio].nameBuilding == "Engenharia")
                   {
                        Instantiate(GameController.Instance.prefabBirdder,GameController.Instance.content.transform);
                        Birdder.instance.textMessage.text = Reader.instance.EngenhariaMsg();
                   }
                   else if(GameController.Instance.predios[UIVariables.Instance.currentPredio].nameBuilding == "Humanas")
                   {
                        Instantiate(GameController.Instance.prefabBirdder,GameController.Instance.content.transform);
                        Birdder.instance.textMessage.text = Reader.instance.HumanasMsg();
                   }
                   else if(GameController.Instance.predios[UIVariables.Instance.currentPredio].nameBuilding == "Medicina")
                   {
                        Instantiate(GameController.Instance.prefabBirdder,GameController.Instance.content.transform);
                        Birdder.instance.textMessage.text = Reader.instance.MedicinaMsg();
                   }
                    UpConstruction.Instance.UpgradeConstrucao();
                    tween.CloseUpConstrucao();
                }else{
                    screenInsufficientMoney.SetActive(true);
                    tween.ErroCompUp();
                }
            }
        }

        public void BtnComprar(){
            if(coin.Value>=GameController.Instance.predios[currentConst].price){
                Instantiate(GameController.Instance.predios[currentConst].asset, position, rotation);
                GameController.Instance.predios[currentConst].spawned = true;
                GameManager.Instance.DiminuirMoedas(GameController.Instance.predios[currentConst].price);
                GameManager.Instance.IncrementarEstudantes(10);
                tween.ConfContrProf();
                tween.CloseProfMenu();
                
                if(GameController.Instance.predios[currentConst].nameBuilding == "Artes cenicas")
                {
                        Instantiate(GameController.Instance.prefabBirdder,GameController.Instance.content.transform);
                        Birdder.instance.textMessage.text = Reader.instance.ArtesMsg();
                }
                else if(GameController.Instance.predios[currentConst].nameBuilding == "Engenharia")
                {
                        Instantiate(GameController.Instance.prefabBirdder,GameController.Instance.content.transform);
                        Birdder.instance.textMessage.text = Reader.instance.EngenhariaMsg();
                }
                else if(GameController.Instance.predios[currentConst].nameBuilding == "Humanas")
                {
                        Instantiate(GameController.Instance.prefabBirdder,GameController.Instance.content.transform);
                        Birdder.instance.textMessage.text = Reader.instance.HumanasMsg();
                }
                else if(GameController.Instance.predios[currentConst].nameBuilding == "Medicina")
                {
                        Instantiate(GameController.Instance.prefabBirdder,GameController.Instance.content.transform);
                        Birdder.instance.textMessage.text = Reader.instance.MedicinaMsg();
                }

            }else{
                screenInsufficientMoney.SetActive(true);
                tween.ErroContrProf();
            }
        }   

        public void ConfirmarNameCollege(){
            Time.timeScale = 1f;
            CameraController.instance.speed = 5.0f;
            CameraController.instance.movimentTime = 1.5f;
            CameraController.instance.rotationValue = 1.0f;
            tween.CloseNameCollege();
        }


        public void HideScreenInsMoney(){
            screenInsufficientMoney.SetActive(false);
        }

        public void TutorialGame(){
            SaveControler.Save();
            tutorialActive.Value = true;
            SceneManager.LoadScene("Menu");
        }
        public void Game(){
            SceneManager.LoadScene("Game");
            
        }
        public void Menu(){
            SceneManager.LoadScene("Menu");
            SaveControler.Save();
        }
    }
}
