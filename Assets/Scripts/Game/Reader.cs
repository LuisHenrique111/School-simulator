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
    [SerializeField] TextAsset fileNames,fileSocial;

    [Header("Arrays")]
    ArrayList singleNames = new ArrayList();
    public ArrayList listNames = new ArrayList();
    public ArrayList listSocial = new ArrayList();

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

        var text = fileSocial.text.Split(lineBreak,StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < text.Length; i++)
        {
            listSocial.Add(text[i]); 
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
    public string Message()
    {
        int rnd = Random.Range(0,listSocial.Count);
        return listSocial[rnd].ToString();
    }


}
