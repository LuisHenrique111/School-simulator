using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Data;

public class SaveAdapter : MonoBehaviour
{
    public static GameObject Data2Building(BuildingSaveData data){
        BuildingData obj = new BuildingData();
        GameObject b = new GameObject();
        if(GameController.Instance.predios[data.level].spawned == true){
            if(GameController.Instance.predios[data.level].nivel == 1){
                obj = GameManager.Instance.predios[data.level];
                b = Instantiate(obj.asset, data.position, Quaternion.Euler(data.rotation));
            }else if(GameController.Instance.predios[data.level].nivel == 2){
                obj = GameManager.Instance.predios[data.level];
                b = Instantiate(obj.evolutionAsset[0], data.position, Quaternion.Euler(data.rotation));
            }else if(GameController.Instance.predios[data.level].nivel == 3){
                obj = GameManager.Instance.predios[data.level];
                b = Instantiate(obj.evolutionAsset[1], data.position, Quaternion.Euler(data.rotation));
            }
            
        }         
        return b;
        //b.GetComponent<Building>().level = data.level;
    }

    public static BuildingSaveData Building2Data(Building building){
        BuildingSaveData data = new BuildingSaveData();
        data.position = building.transform.position;
        data.rotation = building.transform.rotation.eulerAngles;
        data.level = building.level;
        return data;
    }


}
