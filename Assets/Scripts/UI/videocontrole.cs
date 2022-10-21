using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videocontrole : MonoBehaviour
{
    private static videocontrole instace;
    [SerializeField]
    private GameObject videoPrincipal;
    [SerializeField]
    private List<GameObject> videosSecundarios = new List<GameObject>();
    public void ChangerVideo(GameObject video)
    {
        videoPrincipal = video;
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
