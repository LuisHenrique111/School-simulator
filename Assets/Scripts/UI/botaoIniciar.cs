using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botaoIniciar : MonoBehaviour
{
    public string nomeCena;
    

    public void BtnMudaCena()
    {   
        if(nomeCena == "Game"){
            GameManager.Instance.newGame.Value = true;
        }
        SceneManager.LoadScene(nomeCena);
        Debug.Log("voltou");
    }

    public void BtnContinuar()
    {   
        if(nomeCena == "Game"){
            GameManager.Instance.newGame.Value = false;
        }
        SceneManager.LoadScene(nomeCena);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}

