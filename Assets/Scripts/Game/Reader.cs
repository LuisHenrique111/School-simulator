using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Reader : MonoBehaviour
{
    public static Reader instance;

    [Header("Files")]
    [SerializeField] TextAsset fileNames,fileSocialRuim,fileSocialBom;
    
    [Header("Arrays")]
    public string[] tips;
    public string[] msgHumanas;
    public string[] msgMedicina;
    public string[] msgArtes;
    public string[] msgEngenharia;
    ArrayList singleNames = new ArrayList();
    public ArrayList listNames = new ArrayList();
    public ArrayList listSocialRuim = new ArrayList();
    public ArrayList listSocialBom = new ArrayList();

    void Awake() 
    {
        instance = this;
        ReadFileName();
        ReadFileSocial();
    }

    public void ReadFileName()
    {
        var lineBreak = new string [] {"\r\n","\r","\n"};

        var name = fileNames.text.Split(lineBreak,StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < name.Length; i++)
        {
            singleNames.Add(name[i]); 
        }
    }
    public void ReadFileSocial()
    {
        var lineBreak = new string [] {"\r\n","\r","\n"};

        var text = fileSocialRuim.text.Split(lineBreak,StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < text.Length; i++)
        {
            listSocialRuim.Add(text[i]); 
        }

        var text1 = fileSocialBom.text.Split(lineBreak,StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < text1.Length; i++)
        {
            listSocialBom.Add(text1[i]); 
        }
    }

    public string GenerateName()
    {
        int rnd = Random.Range(0,singleNames.Count);
        int rnd2 = Random.Range(0,singleNames.Count);

        if(rnd != rnd2)
        {
            var name = singleNames[rnd].ToString() + " " + singleNames[rnd2].ToString();
            listNames.Add(name);
            return name;

        }
        return GenerateName();
    }

    public string Issuer()
    {
        if(listNames != null)
        {
            int rnd = Random.Range(0,listNames.Count);
            return listNames[rnd].ToString() +":";
        }
        return null;
    
    }
    public string GoodMessage()
    {
        int rnd = Random.Range(0,listSocialBom.Count);
        return listSocialBom[rnd].ToString();
    }
    public string BadMessage()
    {
        int rnd = Random.Range(0,listSocialRuim.Count);
        return listSocialRuim[rnd].ToString();
    }
    public string HumanasMsg()
    {
        int rnd = Random.Range(0,msgHumanas.Length);
        return msgHumanas[rnd];
    }
    public string MedicinaMsg()
    {
        int rnd = Random.Range(0,msgMedicina.Length);
        return msgMedicina[rnd];
    }
    public string ArtesMsg()
    {
        int rnd = Random.Range(0,msgArtes.Length);
        return msgArtes[rnd];
    }
    public string EngenhariaMsg()
    {
        int rnd = Random.Range(0,msgEngenharia.Length);
        return msgEngenharia[rnd];
    }


}
