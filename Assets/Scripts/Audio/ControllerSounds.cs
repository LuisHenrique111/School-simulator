using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Variables;

public class ControllerSounds : MonoBehaviour
{
    
    public Slider slider;
    public AudioSource audio;

    public Slider sliderES;
    public AudioSource audioES;
    public Slider sliderMusic;

    public GameObject check;
    public GameObject noCheck;

    public FloatVariable musicVariable;
    public FloatVariable efeitosVariable;
    public FloatVariable volumeVariable;
    public BoolVariable isAudio;

    public static ControllerSounds instance;

    void Start(){
        instance = this;
        if(isAudio.Value == true){
            check.SetActive(true);
            noCheck.SetActive(false);
        }else{
            noCheck.SetActive(true);
            check.SetActive(false);
        }
    }

    void Update(){
        audioES.volume = efeitosVariable.Value;
        sliderES.value = efeitosVariable.Value;
        audio.volume = musicVariable.Value;        
        sliderMusic.value = musicVariable.Value;
        slider.value = volumeVariable.Value;
        AudioListener.volume = volumeVariable.Value;
        
    }
    public void MudarVolume(){
        volumeVariable.Value = slider.value;
        AudioListener.volume = volumeVariable.Value;
    } 

    public void EfeitosSonoros(){
        efeitosVariable.Value = sliderES.value;
        audioES.volume = efeitosVariable.Value;
    }

    public void Musica(){
        musicVariable.Value = sliderMusic.value;
        audio.volume = musicVariable.Value;
    }

    public void DesativaAudio(){
        isAudio.Value = true;
        check.SetActive(true);
        noCheck.SetActive(false);
        musicVariable.Value = 0f;
        audio.volume = musicVariable.Value;
        efeitosVariable.Value = 0f;
        audioES.volume = efeitosVariable.Value;
        
    }

    public void AtivaAudio(){
        isAudio.Value = false;
        noCheck.SetActive(true);
        check.SetActive(false);
        musicVariable.Value = 0.3f;
        audio.volume = musicVariable.Value;
        efeitosVariable.Value = 0.3f;
        audioES.volume = efeitosVariable.Value;
        
    }
}
