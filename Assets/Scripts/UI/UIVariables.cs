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
        [Header("UI professor store")]
        public Slider sliderCarisma;
        public Slider sliderDidatica;
        public Slider sliderDiciplina;
        public TMP_Text salario;
        public Image imagemProfessor;
        public TMP_Text nameTeacher;
        public int currentProf=0;
        #endregion

        [Header("telas")]
        public GameObject screenInsufficientMoney;
        public bool isGame;

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
            }
            
        }

        public void NextProf(){
            currentProf = (currentProf + 1) % GameController.Instance.teachers.Length;
            sliderCarisma.value = GameController.Instance.teachers[currentProf].carisma;
            sliderDidatica.value = GameController.Instance.teachers[currentProf].didatica;
            sliderDiciplina.value = GameController.Instance.teachers[currentProf].diciplina;
            salario.text = GameController.Instance.teachers[currentProf].price.ToString();
            imagemProfessor.sprite = GameController.Instance.teachers[currentProf].UISprite;
            nameTeacher.text = GameController.Instance.teachers[currentProf].nameTeacher;
        }

        public void PrevProf(){
            sliderCarisma.value = GameController.Instance.teachers[currentProf].carisma;
            sliderDidatica.value = GameController.Instance.teachers[currentProf].didatica;
            sliderDiciplina.value = GameController.Instance.teachers[currentProf].diciplina;
            salario.text = GameController.Instance.teachers[currentProf].price.ToString();
            imagemProfessor.sprite = GameController.Instance.teachers[currentProf].UISprite;
            nameTeacher.text = GameController.Instance.teachers[currentProf].nameTeacher;
            currentProf--;

            if (currentProf < 0)
            {
                currentProf += GameController.Instance.teachers.Length;
            }
        }

        public void BtnContratacao(){
            
            if(coin.Value>=GameController.Instance.teachers[currentProf].price){
                GameController.Instance.teachers[currentProf].contratado = true;
                GameManager.Instance.DiminuirMoedas(GameController.Instance.teachers[currentProf].price);
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
