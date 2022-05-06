using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class alunoss : MonoBehaviour
{
   public float tempoAtePonto;
    public float alunoSpeed  = 1000;
    public bool goingToBusStop=false;

    NavMeshAgent navMesh;

    private void Update()
    {
        //Debug.Log(navMesh.destination);
    }
    public void alunosAndar (Vector3 destino){
        Debug.Log(destino);

        navMesh.isStopped = false;
        Debug.Log(navMesh.SetDestination(new Vector3(destino.x,0,destino.z)));
        //navMesh.destination = destino;
        Debug.Log(navMesh.destination);
        //navMesh.speed = alunoSpeed;

   }
   private void OnTriggerEnter(Collider other)
   {
       if(other.CompareTag("casa")){
            Debug.Log("colidiu com casa");
            navMesh.isStopped = true;
            //navMesh.speed = 0;

            StartCoroutine(espera());
       }
   }
    IEnumerator espera(){

        yield return new WaitForSeconds(1);
        goingToBusStop = true;
        alunosAndar(teste.instance.pontoDeOnibus.position);
    }
    void Awake(){
        navMesh = transform.GetComponent<NavMeshAgent>();
    }
}
