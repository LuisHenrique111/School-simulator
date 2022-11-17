using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentsWalkingState : Entity.State
{
    
    public Transform[] wayPointsCont;
    public int currentWayPoint = 0; 
    Transform targetWayPoint;
    GameObject aux;

    public float speed = 4f;
    public float auxSpeed;
    public bool insideClassroom;
    public float time;

    public GameObject wayPoints;
    public int currentBuilding;
    public int inside;
    

    public override void OnEnter(){
        currentBuilding = Random.Range(1,4);
        if(currentBuilding == 1){
            wayPoints = GameObject.Find("WayPoints1");
        }else if(currentBuilding == 2){
            wayPoints = GameObject.Find("WayPoints2");
        }else if(currentBuilding == 3){
            wayPoints = GameObject.Find("WayPoints3");
        }else if(currentBuilding == 4){
            wayPoints = GameObject.Find("WayPoints4");
        }
        
        wayPointsCont = wayPoints.GetComponentsInChildren<Transform>();

        speed = Random.Range(20, 40);
        
    }


    // Update is called once per frame
    void Update () {

        // check if we have somewere to walk
        if(currentWayPoint < wayPointsCont.Length)
        {
            if(targetWayPoint == null)
                targetWayPoint = wayPointsCont[currentWayPoint];
            walk();
        }
        if(insideClassroom == true){
            inside++;
            speed = 0.0f;
            time = time + Time.deltaTime;
            StopClassroom();
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
            if(currentWayPoint == wayPointsCont.Length){
                currentWayPoint=0;
            }
            targetWayPoint = wayPointsCont[currentWayPoint];
            
        }
    }

    void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.tag == "Predios"){
            insideClassroom = true;
            auxSpeed = speed;
            GameManager.Instance.AumentarMoedas(50);
        }

        if(other.gameObject.tag == "Fim" && inside > 0)
        {
            entity.SetState<StudentsGoWayState>();
        }
        else if(other.gameObject.tag == "Fim" && inside <= 0)
        {
            Instantiate(GameController.Instance.prefabBirdder,GameController.Instance.content.transform);
            gameObject.GetComponent<NPC_control>().individualHappiness -= 40;
            entity.SetState<StudentsGoWayState>();
            GameManager.Instance.DiminuirMoedas(30);
        }
    }

    public void StopClassroom(){
        if(time > 10.0f){
            speed = auxSpeed;
            gameObject.GetComponent<NPC_control>().individualHappiness += 20;
            insideClassroom = false;  
        }
    }
}
