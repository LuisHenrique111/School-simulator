using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentsWalkingState : Entity.State
{
    // put the points from unity interface
    public Transform[] wayPointList;

    public int currentWayPoint = 0; 
    Transform targetWayPoint;
    GameObject aux;

    public float speed = 4f;

    public override void OnEnter(){
        
        /*for(int i = 0; i<GameController.Instance.wayPointListController.Length; i++){
            Debug.Log("Entrou");
            wayPointList[i] = GameController.Instance.wayPointListController[i];
        }*/

        speed = Random.Range(3,10);
    }

    void Start(){
        
    }


    // Update is called once per frame
    void Update () {
        // check if we have somewere to walk
        if(currentWayPoint < GameController.Instance.wayPointListController.Length)
        {
            if(targetWayPoint == null)
                targetWayPoint = GameController.Instance.wayPointListController[currentWayPoint];
            walk();
        }
    }

    void walk(){
        // rotate towards the target
        transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed*Time.deltaTime, 0.0f);

        // move towards the target
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position,   speed*Time.deltaTime);

        if(transform.position == targetWayPoint.position)
        {
            currentWayPoint ++ ;
            targetWayPoint = GameController.Instance.wayPointListController[currentWayPoint];
        }
    }
}
