using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UI;


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
        scene.game = new GameSaveData();
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
        scene.game.nivelArtes = GameController.Instance.predios[0].nivel;
        scene.game.nivelEngenharia = GameController.Instance.predios[1].nivel;
        scene.game.nivelHumanas = GameController.Instance.predios[2].nivel;
        scene.game.nivelMedicina = GameController.Instance.predios[3].nivel;
        scene.game.nivelReitoria = GameController.Instance.building[0].nivel;
        scene.game.isSpawnArtes = GameController.Instance.predios[0].spawned;
        scene.game.isSpawnEngenharia = GameController.Instance.predios[1].spawned;
        scene.game.isSpawnHumanas = GameController.Instance.predios[2].spawned;
        scene.game.isSpawnMedicina = GameController.Instance.predios[3].spawned;
        GameManager.Instance.save.Value = true;
        scene.game.audio = ControllerSounds.instance.isAudio.Value;
        scene.game.efeitosSonoros = ControllerSounds.instance.efeitosVariable.Value;
        scene.game.musica = ControllerSounds.instance.musicVariable.Value;
        scene.game.volume = ControllerSounds.instance.volumeVariable.Value;
        scene.game.minutos = UIVariables.Instance.minutes.Value;
        scene.game.hours = UIVariables.Instance.hours.Value;
        scene.game.money = GameManager.Instance.coinManager.Value;
        scene.game.happiness = GameManager.Instance.happiness.Value;
        scene.game.studants = GameManager.Instance.studentsManager.Value;
        scene.game.name = UIVariables.Instance.collegeName.Value;
        scene.game.saveGame = GameManager.Instance.save.Value;
        string s = JsonUtility.ToJson(scene);
        Debug.Log(Application.persistentDataPath + "/saveGame.txt");
        Debug.Log(s);
        File.WriteAllText(Application.persistentDataPath + "/saveGame.txt", s);
    }

    public static void Load(){
        string s = File.ReadAllText(Application.persistentDataPath + "/saveGame.txt");
        Debug.Log(s);
        SceneData data = JsonUtility.FromJson<SceneData>(s);
        GameController.Instance.predios[0].nivel = data.game.nivelArtes;
        GameController.Instance.predios[1].nivel = data.game.nivelEngenharia;
        GameController.Instance.predios[2].nivel = data.game.nivelHumanas;
        GameController.Instance.predios[3].nivel = data.game.nivelMedicina;
        GameController.Instance.predios[0].spawned = data.game.isSpawnArtes;
        GameController.Instance.predios[1].spawned = data.game.isSpawnEngenharia;
        GameController.Instance.predios[2].spawned = data.game.isSpawnHumanas;
        GameController.Instance.predios[3].spawned = data.game.isSpawnMedicina;
        GameController.Instance.building[0].nivel = data.game.nivelReitoria;        
        for(int i = 0; i < data.buildings.Length; i++){
            
            SaveAdapter.Data2Building(data.buildings[i]);
        }
        for(int j=0; j<data.reitoriaBuild.Length; j++){
            
            SaveAdapter.Data2BuildingReitoria(data.reitoriaBuild[j]);
        }
        ControllerSounds.instance.isAudio.Value = data.game.audio;
        ControllerSounds.instance.efeitosVariable.Value = data.game.efeitosSonoros;
        ControllerSounds.instance.musicVariable.Value = data.game.musica;
        ControllerSounds.instance.volumeVariable.Value = data.game.volume;
        UIVariables.Instance.minutes.Value = data.game.minutos;
        UIVariables.Instance.hours.Value = data.game.hours;
        GameManager.Instance.coinManager.Value = data.game.money;
        GameManager.Instance.happiness.Value = data.game.happiness;
        GameManager.Instance.studentsManager.Value = data.game.studants;
        UIVariables.Instance.collegeName.Value = data.game.name;
        GameManager.Instance.save.Value = data.game.saveGame;
        
    }
}
