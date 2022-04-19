using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontoOnibus : MonoBehaviour
{
    public float intervaloRecolhimento;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("aluno"))
        {
            other.transform.parent = transform;
        }
        else if(other.CompareTag("onibus"))
        {
            StartCoroutine(recolherAlunos());
        }
    }


    IEnumerator recolherAlunos()
    {
        alunoss[] alunos = transform.GetComponentsInChildren<alunoss>();
 
        // Remove os alunos 1 por 1
        for(int i=0;i<alunos.Length;i++)
        {
            Destroy(alunos[i].gameObject);
            yield return new WaitForSeconds(intervaloRecolhimento);
        }
    }
}
