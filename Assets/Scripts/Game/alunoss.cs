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
    

    public static alunoss instance;

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
    void Awake(){
        navMesh = transform.GetComponent<NavMeshAgent>();
    }
}
