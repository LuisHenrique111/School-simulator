using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ChangeImage : MonoBehaviour
{
    [SerializeField] VideoPlayer imagemGrande;
    public void SwapImage(VideoPlayer myImage)
    {
        VideoPlayer aux = imagemGrande;
        imagemGrande = myImage;
        myImage = aux;
    }
}
