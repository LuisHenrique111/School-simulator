using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Variables;

namespace Game.Data{
    [CreateAssetMenu(fileName = "Game/Building", menuName = "Game/Building", order =3)]
    public class BuildingData : ScriptableObject{
        public string nameBuilding;
        public Sprite UISpriteBuilding;
        public int nivel;
        public GameObject asset;
        public BuildingType typeMatter;
        public bool spawned;
    }

    [Serializable]
    public enum BuildingType{
        math,
        science,
        history,
        geography,
    }
}
