using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botaoIniciar : MonoBehaviour
{
    public string nomeCena;

    public void BtnMudaCena()
    {
        SceneManager.LoadScene(nomeCena);
    }

    public void QuitGame()
    {

        Debug.Log("Quit!");
        Application.Quit();
    }
}

