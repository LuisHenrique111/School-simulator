using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Variables;
using TMPro;
using UnityEngine.SceneManagement;


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
        public IntVariable minutes;
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
        [Header("UI predios store")]
        public TMP_Text descricaoBuilding;
        public TMP_Text salario;
        public Image imagemProfessor;
        public TMP_Text nameTeacher;
        public Button btnComprar;
        public int currentConst;
        #endregion

        #region store upgrade
        [Header("UI buildings Upgrade 1")]
        public TMP_Text[] precoUpgrade;
        public TMP_Text[] nivel;
        public Image[] imagemUpgrade;
        public Button[] btnUpgrade;
        #endregion


        [Header("telas")]
        public GameObject screenInsufficientMoney;
        public bool isGame;
        public bool isSalaDiretor;

        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
        }

        // Update is called once per frame
        void Update()
        {
            if(isGame){
                
                textCoin.text = coin.Value.ToString();
                textHappiness.text = happiness.Value.ToString();
                textStudents.text = students.Value.ToString();
                textMinutes.text = minutes.Value.ToString();
                textHours.text = GameController.Instance.hours.ToString();

                if(GameController.Instance.predios[currentConst].spawned == false){
                    btnComprar.interactable = true;
                }else{
                    btnComprar.interactable = false;
                }
                VerificaBotaoUpgrade();
                
                
                /*if(!isSalaDiretor){
                    if(GameController.Instance.building[currentConst].contratado == false){
                    btnContratado.interactable = true;
                    }else{
                        btnContratado.interactable = false;
                    }
                    VerificaBotaoUpgrade();
                }*/
            }
            
        }

        public void VerificaBotaoUpgrade(){
            if(coin.Value >= GameController.Instance.building[0].priceEvolution[0]){
                btnUpgrade[0].interactable = true;
            }else{
                btnUpgrade[0].interactable = false;
            }
            if(GameController.Instance.building[0].nivel == 3){
                btnUpgrade[0].interactable = false;
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
            salario.text = GameController.Instance.predios[currentConst].price.ToString();
            imagemProfessor.sprite = GameController.Instance.predios[currentConst].UISpriteBuilding;
            nameTeacher.text = GameController.Instance.predios[currentConst].nameBuilding;
            descricaoBuilding.text = GameController.Instance.predios[currentConst].descricaoBuilding;

            currentConst--;

            if (currentConst < 0)
            {
                currentConst += GameController.Instance.predios.Length;
            }
        }

        public void BtnComprar(){
        if(coin.Value>=GameController.Instance.predios[currentConst].price){
            Instantiate(GameController.Instance.predios[currentConst].asset, position, rotation);
            GameController.Instance.predios[currentConst].spawned = true;
            GameManager.Instance.DiminuirMoedas(GameController.Instance.predios[currentConst].price);
            tween.ConfContrProf();
        }else{
            screenInsufficientMoney.SetActive(true);
            tween.ErroContrProf();
        }
    }


        public void HideScreenInsMoney(){
            screenInsufficientMoney.SetActive(false);
        }

        public void SalaDiretor(){
            SceneManager.LoadScene("Sala_Diretor");
        }
        public void Game(){
            SceneManager.LoadScene("Game");
        }
        public void Menu(){
            SceneManager.LoadScene("Menu");
        }
    }
}
