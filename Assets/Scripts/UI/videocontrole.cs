using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videocontrole : MonoBehaviour
{
    private static videocontrole instace;
    [SerializeField]
    private GameObject videoPrincipal;
    public void ChangerVideo(GameObject video)
    {
        GameObject videoAuxiliar = videoPrincipal;
        videoPrincipal = video;
        video = videoAuxiliar;
    }
    void Awake()
    {
        instace = this;
    } 
    public static videocontrole Instace()
    {
        return instace;
    }

}
