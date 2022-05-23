using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerSounds : MonoBehaviour
{
    public Slider slider;
    public AudioSource audio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MudarVolume(){
        audio.volume = slider.value;
    } 
}
