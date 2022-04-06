using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Data{
    [CreateAssetMenu(fileName = "Game/Teacher", menuName = "Game/Teacher", order = 2)]
    public class TeacherData : ScriptableObject{
        public string nameTeacher;
        public Sprite UISprite;
        public int price;
        public int carisma;
        public int didatica;
        public int diciplina;
        public int rendaHora;
        public float horaRentavel;
        public bool contratado;
    }

}
