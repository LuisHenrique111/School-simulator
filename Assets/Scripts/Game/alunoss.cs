using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Game.Variables;

public class alunoss : MonoBehaviour
{
   public float tempoAtePonto;
    public float alunoSpeed  = 1000;
    public bool goingToBusStop=false;
    
    NavMeshAgent navMesh;

    public bool isOnibus;
    public Vector3 currentDestination;

    public static alunoss instance;

    private void Update()
    {
        //Debug.Log(navMesh.destination);
        
    }
    public void alunosAndar (Vector3 destino){
        navMesh.isStopped = false;
        navMesh.SetDestination(new Vector3(destino.x,0,destino.z));
        //navMesh.destination = destino;


   }
    public void alunosAndar()
    {
        ResetVariables();
        navMesh.isStopped = false;
        navMesh.SetDestination(new Vector3(currentDestination.x, 0, currentDestination.z));
    }
   public void OnTriggerEnter(Collider other)
   {
       if(other.CompareTag("casa")){
            Debug.Log("colidiu com casa");
            navMesh.isStopped = true;
            //navMesh.speed = 0;

            StartCoroutine(espera());
       }
       if(isOnibus){
           if(other.CompareTag("PontoOnibus")){
                int random = Random.Range(0,100);
                if(random>=GameManager.Instance.porcentagemGanho.Value){
                    GameManager.Instance.GanhoFelicidade(10);
                }else{
                    GameManager.Instance.PerdaFelicidade(10);
                }
            }
       }
       
   }
    IEnumerator espera(){

        yield return new WaitForSeconds(1);
        goingToBusStop = true;
        alunosAndar(teste.instance.pontoDeOnibus.position);
        isOnibus = true;
    }
    void ResetVariables()
    {
        isOnibus = false;
        goingToBusStop = false;
    }
    void Awake(){
        navMesh = transform.GetComponent<NavMeshAgent>();
    }
}
