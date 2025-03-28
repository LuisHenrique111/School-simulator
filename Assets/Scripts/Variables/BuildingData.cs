using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Variables;

namespace Game.Data{
    [CreateAssetMenu(fileName = "Game/Building", menuName = "Game/Building", order =3)]
    public class BuildingData : ScriptableObject{
        public string nameBuilding;
        public string descricaoBuilding;   
        public Sprite UISpriteBuilding;
        public int countStudents;
        public int nivel;
        public GameObject asset;
        public GameObject[] evolutionAsset;
        public BuildingType typeMatter;
        public bool spawned;
        public int price;
        public int[] priceEvolution;
    }

    [Serializable]
    public enum BuildingType{
        Reitoria,
        Engenharia,
        Medicina,
        ArtesCenicas,
        Humanas,
    }
}
