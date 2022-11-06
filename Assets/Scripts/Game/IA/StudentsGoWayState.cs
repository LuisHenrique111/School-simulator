using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentsGoWayState : Entity.State
{
    public int continueWalking;
    public override void OnEnter(){
        continueWalking = Random.Range(0,100);
        
    }

    void Update(){
        if(continueWalking<50){
            entity.SetState<StudentsWalkingState>();
        }else{
            SpawnNPC.Instance.contador--;
            Destroy(gameObject);
        }
    }
}
