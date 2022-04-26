using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class alunoss : MonoBehaviour
{
   public float tempoAtePonto;
    NavMeshAgent navMesh;
   public void alunosAndar (Vector3 destino){
       navMesh.SetDestination(destino);
   }
   private void OnTriggerEnter(Collider other)
   {
       if(other.CompareTag("casa")){
           StartCoroutine(espera());
       }
   }
    IEnumerator espera(){
        yield return new WaitForSeconds(tempoAtePonto);
        alunosAndar(teste.instance.pontoDeOnibus.position);
    }
    void Awake(){
        navMesh = transform.GetComponent<NavMeshAgent>();
    }
}
