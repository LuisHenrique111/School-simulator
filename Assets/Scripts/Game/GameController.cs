using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Data;
using Game.Variables;
using Game.Variables.Generic;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    [Header("Vetor dos professores")]
    public TeacherData[] teachers;

    [Header("Variaveis globais")] 
    #region variaveis globais 
    public FloatVariable seconds;
    public int hours;
    public IntVariable minutes;
    public IntVariable coin;
    #endregion
    

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        seconds.Value = 1.0f;
        hours = 0;
    }

    // Update is called once per frame
    void Update()
    {
        seconds.Value = seconds.Value + Time.deltaTime;
        minutes.Value = (int)seconds.Value;
        
        if(seconds.Value >= 60){
            seconds.Value = 0;
            minutes.Value = 0;
            hours = hours + 1;
            profit();
        }
    }

    public void profit(){
        for(int i = 0; i< teachers.Length; i++){
            if(teachers[i].contratado == true && ((hours % teachers[i].horaRentavel) == 0)){
                coin.Value = coin.Value + teachers[i].rendaHora;
            }
        }
    }
}
