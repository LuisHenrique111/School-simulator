using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI{
    public class Tween : MonoBehaviour
    {
        [SerializeField]
        GameObject constructionBG, constructionInfo, profMenu, sidePanel, sidepanelBt, menuPanel, erroContProf, erroCompUp,
            const1, const2, const3, stamp, GameOverBtMenu, GameOverBtNovo, GameOverBtSair, UpConstruction, nameCollege;
        
        [SerializeField]
        CanvasGroup aConsBox, amenuPanel;

        int sideMenu = 1;

        public GameObject[] upgradeConstructionUI;
        public GameObject professor;
        public Button contratarProf;
        public Button comprarUp;
        public Color erroColorBt;
        public Color confirmColorBt;

        public AnimationCurve stampCurve;

        public static Tween Instance;

        public GameObject[] tutorial;
        public int currentPag;


        

        void Start()
        {
            Instance = this;
            LeanTween.scale(stamp, (stamp.transform.localScale) / 150, 1f).setEase(LeanTweenType.easeInQuint);
            LeanTween.moveLocalY(GameOverBtMenu, -190, 1f).setDelay(0.8f).setEase(LeanTweenType.easeInOutCubic);
            LeanTween.moveLocalY(GameOverBtNovo, -310, 1f).setDelay(1f).setEase(LeanTweenType.easeInOutCubic);
            LeanTween.moveLocalY(GameOverBtSair, -310, 1f).setDelay(1.2f).setEase(LeanTweenType.easeInOutCubic);
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
            LeanTween.moveLocalY(constructionBG, -220f, 1f).setEase(LeanTweenType.easeOutCubic);

            //LeanTween.alphaCanvas(aConsBox, 1, 0.5f).setDelay(.7f);
        }
        public void CloseConstructionMenu()
        {
            LeanTween.moveLocalY(constructionBG, -920f, 1f).setEase(LeanTweenType.easeOutCubic).setOnComplete(DesativaConstMenu);

            //LeanTween.alphaCanvas(aConsBox, 1, 0.5f).setDelay(.7f);
        }
        void DesativaConstMenu()
        {
            constructionBG.SetActive(false);
            constructionInfo.SetActive(false);
        }    
        void DesativaProfMenu()
        {
            profMenu.SetActive(false);
        }

        public void OpenProfMenu()
        {
            profMenu.SetActive(true);
            LeanTween.moveLocalY(profMenu, 0f, 1f).setEase(LeanTweenType.easeOutCubic);
            UIVariables.Instance.salario.text = GameController.Instance.predios[UIVariables.Instance.currentConst].price.ToString();
            UIVariables.Instance.imagemProfessor.sprite = GameController.Instance.predios[UIVariables.Instance.currentConst].UISpriteBuilding;
            UIVariables.Instance.nameTeacher.text = GameController.Instance.predios[UIVariables.Instance.currentConst].nameBuilding;
            UIVariables.Instance.descricaoBuilding.text = GameController.Instance.predios[UIVariables.Instance.currentConst].descricaoBuilding;
        }    
        public void CloseProfMenu()
        {
            LeanTween.moveLocalY(profMenu, -900f, 1f).setEase(LeanTweenType.easeOutCubic).setOnComplete(DesativaProfMenu);
        }

        public void OpenUpgrade(int index){
            upgradeConstructionUI[index].SetActive(true);
            LeanTween.moveLocalY(upgradeConstructionUI[index],  0f, 1f).setEase(LeanTweenType.easeOutCubic);
            if(GameController.Instance.building[index].nivel == 1 && GameManager.Instance.coinManager.Value >= GameController.Instance.building[index].priceEvolution[0]){
                UIVariables.Instance.precoUpgrade[index].text = GameController.Instance.building[index].priceEvolution[0].ToString();
                UIVariables.Instance.nivel[index].text = GameController.Instance.building[index].nivel.ToString();
                UIVariables.Instance.imagemUpgrade[index].sprite = GameController.Instance.building[index].UISpriteBuilding;
            }else if(GameController.Instance.building[index].nivel == 2 && GameManager.Instance.coinManager.Value >= GameController.Instance.building[index].priceEvolution[1]){
                UIVariables.Instance.precoUpgrade[index].text = GameController.Instance.building[index].priceEvolution[1].ToString();
                UIVariables.Instance.nivel[index].text = GameController.Instance.building[index].nivel.ToString();
                UIVariables.Instance.imagemUpgrade[index].sprite = GameController.Instance.building[index].UISpriteBuilding;
            }
        }

        public void CloseUpConst(int index)
        {
            LeanTween.moveLocalY(upgradeConstructionUI[index],  -900f, 1f).setEase(LeanTweenType.easeOutCubic);
            upgradeConstructionUI[index].SetActive(false);
        }

        public void ErroContrProf()
        {
            ColorBlock cb = contratarProf.colors;
            cb.selectedColor = erroColorBt;
            contratarProf.colors = cb;
            
            contratarProf.colors = cb;
            //contratarProf.GetComponent<Button>().interactable = false;
            erroContProf.SetActive(true);
            LeanTween.moveLocalY(erroContProf, 60f, 0.5f).setEase(LeanTweenType.easeInOutCubic);
        }

        public void ErroCompUp()
        {
            ColorBlock cb = comprarUp.colors;
            cb.selectedColor = erroColorBt;
            comprarUp.colors = cb;
            //contratarProf.GetComponent<Button>().interactable = false;
            erroCompUp.SetActive(true);
            LeanTween.moveLocalY(erroCompUp, 60f, 0.5f).setEase(LeanTweenType.easeInOutCubic);
        }

        public void ConfContrProf()
        {
            ColorBlock cb = contratarProf.colors;
            cb.pressedColor = confirmColorBt;
            //cb.selectedColor = confirmColorBt;
            contratarProf.colors = cb;
        }

        public void CloseErrorCompraUp()
        {
            LeanTween.moveLocalY(erroCompUp, -750f, 1f).setEase(LeanTweenType.easeOutCubic).setOnComplete(DesativaErrorCompraUp);
        }
        void DesativaErrorCompraUp()
        {
            erroCompUp.SetActive(false);
        }

        public void CloseError()
        {
            LeanTween.moveLocalY(erroContProf, -750f, 1f).setEase(LeanTweenType.easeOutCubic).setOnComplete(DesativaError);
        }
        void DesativaError()
        {
            erroContProf.SetActive(false);
        }

        public void StampOn()
        {
            LeanTween.scale(stamp, (stamp.transform.localScale)/150, 1f).setEase(LeanTweenType.easeInQuint);
        }


        void DesativaUpConstrucao()
        {
            UpConstruction.SetActive(false);
        }

        public void OpenUpConstrucao()
        {
            UpConstruction.SetActive(true);
            LeanTween.moveLocalY(UpConstruction, 0f, 1f).setEase(LeanTweenType.easeOutCubic);
            if( GameController.Instance.predios[UIVariables.Instance.currentPredio].nivel == 1){
                UIVariables.Instance.InfoUpgradePredios(0);
            }
            else if( GameController.Instance.predios[UIVariables.Instance.currentPredio].nivel == 2){
                UIVariables.Instance.InfoUpgradePredios(1);
            }
            
        }    
        public void CloseUpConstrucao()
        {
            LeanTween.moveLocalY(UpConstruction, -900f, 1f).setEase(LeanTweenType.easeOutCubic).setOnComplete(DesativaUpConstrucao);
        }

        public void QuitGame()
        {
            SaveControler.Save();
            Debug.Log("Quit!");
            Application.Quit();
        }

        public void NameCollege()
        {
            nameCollege.SetActive(true);
            LeanTween.moveLocalY(nameCollege, 60f, 0.5f).setEase(LeanTweenType.easeInOutCubic);
        }

        public void CloseNameCollege()
        {
            LeanTween.moveLocalY(nameCollege, -946f, 1f).setEase(LeanTweenType.easeOutCubic).setOnComplete(DesativaErrorCompraUp);
        }
        void DesativaNameCollege()
        {
            nameCollege.SetActive(false);
        }

        public void nextPag(){
            tutorial[currentPag].SetActive(false);
            currentPag++;   
            if(currentPag<6)             
                tutorial[currentPag].SetActive(true);
            
        }

        public void prevPag(){
            tutorial[currentPag].SetActive(false);
            currentPag--;            
            tutorial[currentPag].SetActive(true);
            if(currentPag == 0){
                currentPag = 0;
            }
        }

        public void finalizar(){
            for(int i = 0; i<tutorial.Length; i++){
                tutorial[i].SetActive(false);
            }
        }

    }
}

