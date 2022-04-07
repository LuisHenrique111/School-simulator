using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI{
    public class Tween : MonoBehaviour
    {
        [SerializeField]
        GameObject constructionBG, constructionInfo, profMenu, sidePanel, sidepanelBt, menuPanel, erroContProf,
            const1, const2, const3;
        
        [SerializeField]
        CanvasGroup aConsBox, amenuPanel;

        public GameObject[] prof;
        public int activeProf = 0;
        int sideMenu = 1;


        public GameObject professor;
        public Button contratarProf;
        public Color erroColorBt;
        public Color confirmColorBt;


        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            /*if (sidepanelBt.transform.position.x != -755){
                 sidepanelBt.GetComponent<Button>().interactable = false;
            }else
            {
                 sidepanelBt.GetComponent<Button>().interactable = true;
            }*/
        }


        public void Menu()
        {
            menuPanel.SetActive(true);
            LeanTween.alphaCanvas(amenuPanel, 1, .2f);
        }
        public void FechaMenu()
        {
            LeanTween.alphaCanvas(amenuPanel, 0, .2f).setOnComplete(DesativaMenu);
        }

        void DesativaMenu()
        {
            menuPanel.SetActive(false);
        }

        
        public void OpenSidePanel()
        {
            if (sideMenu == 1)
            {
                LeanTween.moveLocalX(sidePanel, -55f, 1f).setEase(LeanTweenType.easeOutCubic);
                LeanTween.moveLocalX(sidepanelBt, -755, 1f).setEase(LeanTweenType.easeOutCubic);
                LeanTween.rotateAround(sidepanelBt, Vector3.forward, -180, 1f).setEase(LeanTweenType.easeInOutCirc).setOnComplete(SideMenuSwitcher);
                
            } else
            {
                LeanTween.moveLocalX(sidePanel, -220f, 1f).setEase(LeanTweenType.easeOutCubic);
                LeanTween.moveLocalX(sidepanelBt, -910, 1f).setEase(LeanTweenType.easeOutCubic);
                LeanTween.rotateAround(sidepanelBt, Vector3.forward, -180, 1f).setEase(LeanTweenType.easeInOutCirc).setOnComplete(SideMenuSwitcher);
                
            }
        }

        void SideMenuSwitcher()
        {
            sideMenu = sideMenu * -1;
        }
        public void OpenConstructionMenu()
        {
            LeanTween.moveLocalY(constructionBG, -190f, 1f).setEase(LeanTweenType.easeOutCubic);

            //LeanTween.alphaCanvas(aConsBox, 1, 0.5f).setDelay(.7f);
        }
        public void CloseConstructionMenu()
        {
            LeanTween.moveLocalY(constructionBG, -608f, 1f).setEase(LeanTweenType.easeOutCubic).setOnComplete(DesativaConstMenu);

            //LeanTween.alphaCanvas(aConsBox, 1, 0.5f).setDelay(.7f);
        }
        void DesativaConstMenu()
        {
            constructionBG.SetActive(false);
        }    
        void DesativaProfMenu()
        {
            profMenu.SetActive(false);
        }

        public void OpenProfMenu()
        {
            LeanTween.moveLocalY(profMenu, 0f, 1f).setEase(LeanTweenType.easeOutCubic);
            UIVariables.Instance.sliderCarisma.value = GameController.Instance.teachers[UIVariables.Instance.currentProf].carisma;
            UIVariables.Instance.sliderDidatica.value = GameController.Instance.teachers[UIVariables.Instance.currentProf].didatica;
            UIVariables.Instance.sliderDiciplina.value = GameController.Instance.teachers[UIVariables.Instance.currentProf].diciplina;
            UIVariables.Instance.salario.text = GameController.Instance.teachers[UIVariables.Instance.currentProf].price.ToString();
            UIVariables.Instance.imagemProfessor.sprite = GameController.Instance.teachers[UIVariables.Instance.currentProf].UISprite;
            UIVariables.Instance.nameTeacher.text = GameController.Instance.teachers[UIVariables.Instance.currentProf].nameTeacher;
        }    
        public void CloseProfMenu()
        {
            LeanTween.moveLocalY(profMenu, -350f, 1f).setEase(LeanTweenType.easeOutCubic).setOnComplete(DesativaProfMenu);
        }

        public void ErroContrProf()
        {
            ColorBlock cb = contratarProf.colors;
            cb.selectedColor = erroColorBt;
            contratarProf.colors = cb;
            //contratarProf.GetComponent<Button>().interactable = false;
            erroContProf.SetActive(true);
            LeanTween.moveLocalY(erroContProf, 90f, 0.5f).setEase(LeanTweenType.easeInOutCubic);
        }

        public void ConfContrProf()
        {
            ColorBlock cb = contratarProf.colors;
            cb.pressedColor = confirmColorBt;
            //cb.selectedColor = confirmColorBt;
            contratarProf.colors = cb;
        }

        public void CloseError()
        {
            LeanTween.moveLocalY(erroContProf, -750f, 1f).setEase(LeanTweenType.easeOutCubic).setOnComplete(DesativaError);
        }
        void DesativaError()
        {
            erroContProf.SetActive(false);
        }






















        public void QuitGame()
        {
            Debug.Log("Quit!");
            Application.Quit();
        }

    }
}

