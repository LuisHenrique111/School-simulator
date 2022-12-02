using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] screen;
    public int currentScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentScreen == 0){
            screen[0].SetActive(true);
        }
        if(currentScreen<0){
            currentScreen = screen.Length-1;
            screen[screen.Length-1].SetActive(true);
        }
    }

    public void next(){
        screen[currentScreen].SetActive(false);
        currentScreen++;
        if(currentScreen<screen.Length){
            screen[currentScreen].SetActive(true);
        }else{
            currentScreen = 0;
        }
    }

    public void previous(){
        screen[currentScreen].SetActive(false);
        currentScreen--;
        screen[currentScreen].SetActive(true);
        
    }
}
