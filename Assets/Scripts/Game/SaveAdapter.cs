using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Data;

public class SaveAdapter : MonoBehaviour
{
    public static GameObject Data2Building(BuildingSaveData data){

        BuildingData obj = GameManager.Instance.predios[data.level];
        GameObject b = Instantiate(obj.asset, data.position, Quaternion.Euler(data.rotation));
        Debug.Log("Instanciado: " + b.name);
        //b.GetComponent<Building>().level = data.level;
        return b;
    }

    public static BuildingSaveData Building2Data(Building building){
        BuildingSaveData data = new BuildingSaveData();
        data.position = building.transform.position;
        data.rotation = building.transform.rotation.eulerAngles;
        data.level = building.level;
        return data;
    }


}
