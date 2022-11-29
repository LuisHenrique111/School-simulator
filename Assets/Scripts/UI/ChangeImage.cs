using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class ChangeImage : MonoBehaviour
{
    [SerializeField] VideoPlayer imagemGrande;
    [SerializeField] RawImage RawimagemGrande;
    public void SwapImage(VideoPlayer myImage)
    {
        RawImage rawImagePequeno = GetComponent<RawImage>();
        VideoPlayer aux = imagemGrande;
        VideoPlayer aux2 = myImage;
        Texture rawImageAUX = RawimagemGrande.texture;
        Texture rawImageAUX2 = rawImagePequeno.texture;
        //Debug.Log(rawImageAUX.name);

        RawimagemGrande.texture = rawImagePequeno.texture;
        imagemGrande.clip = aux2.clip; //
        imagemGrande.targetTexture = myImage.targetTexture; //
        imagemGrande.Play();

        rawImagePequeno.texture = rawImageAUX;
        myImage.clip = aux.clip;
        myImage.targetTexture = aux.targetTexture;
        myImage.Stop();

    }

    
}
