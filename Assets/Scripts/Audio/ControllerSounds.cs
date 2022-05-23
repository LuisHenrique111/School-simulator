using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerSounds : MonoBehaviour
{
    public Slider slider;
    public AudioSource audio;
    public void MudarVolume(){
        audio.volume = slider.value;
    } 
}
