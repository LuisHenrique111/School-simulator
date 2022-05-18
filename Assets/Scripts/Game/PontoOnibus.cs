using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontoOnibus : MonoBehaviour
{
    public float intervaloRecolhimento;
   public GameObject aluno ;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("aluno"))
        {
            if(other.GetComponent<alunoss>().goingToBusStop)
                other.transform.parent = transform;
        }
        else if(other.CompareTag("onibus"))
        {
            StartCoroutine(addAlunos());
            StartCoroutine(recolherAlunos());
        }
    }

    IEnumerator addAlunos(){
        for (int i = 0; i < teste.instance.quantAlunos.Count; i++)
        {
            //Instantiate(aluno, transform.position, aluno.transform.rotation);
            teste.instance.quantAlunos[i].gameObject.SetActive(true);
           // teste.instance.quantAlunos[i].alunosAndar();
            yield return new WaitForSeconds(0.2f);

        }
        teste.instance.quantAlunos = new List<alunoss>();

    }
    IEnumerator recolherAlunos()
    
    {
        alunoss[] alunos = transform.GetComponentsInChildren<alunoss>();
 
        // Remove os alunos 1 por 1
        for(int i=0;i<alunos.Length;i++)
        {
            //Destroy(alunos[i].gameObject);
            alunos[i].gameObject.SetActive(false);
            teste.instance.quantAlunos.Add(alunos[i]);
            yield return new WaitForSeconds(intervaloRecolhimento);
        }
    }
}
