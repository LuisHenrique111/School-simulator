using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveControler : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)){
            Save();
        }
    }

    public static void Save(){
        SceneData scene = new SceneData();
        Building[] buildlist = GameObject.FindObjectsOfType<Building>();
        scene.buildings = new BuildingSaveData[buildlist.Length]; 
        for(int i = 0; i < buildlist.Length; i++){
            scene.buildings[i] = SaveAdapter.Building2Data(buildlist[i]);
        }
        Reitoria[] reitoriaList = GameObject.FindObjectsOfType<Reitoria>();
        scene.reitoriaBuild = new BuildingSaveData[reitoriaList.Length];
        for(int j = 0; j<reitoriaList.Length; j++){
            scene.reitoriaBuild[j] = SaveAdapter.Building2DataReitoria(reitoriaList[j]);
        }
        GameManager.Instance.save.Value = true;
        scene.game = new GameSaveData();
        scene.game.time = 0; //salva o tempo
        string s = JsonUtility.ToJson(scene);
        Debug.Log(Application.persistentDataPath + "/saveGame.txt");
        Debug.Log(s);
        File.WriteAllText(Application.persistentDataPath + "/saveGame.txt", s);
    }

    public static void Load(){
        string s = File.ReadAllText(Application.persistentDataPath + "/saveGame.txt");
        Debug.Log(s);
        SceneData data = JsonUtility.FromJson<SceneData>(s);
        for(int i = 0; i < data.buildings.Length; i++){
            SaveAdapter.Data2Building(data.buildings[i]);
        }
        for(int j=0; j<data.reitoriaBuild.Length; j++){
            SaveAdapter.Data2BuildingReitoria(data.reitoriaBuild[j]);
        }
        
    }
}
