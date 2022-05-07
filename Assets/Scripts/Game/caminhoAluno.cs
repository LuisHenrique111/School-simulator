using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class caminhoAluno : MonoBehaviour
{
    [SerializeField] GameObject alunos ;
    public Transform destinationPoint;
    public int quantidadeAlunos;

    public static caminhoAluno instance;

    void Start()
    {
        instance = this;
    }
    public void CreateCasa(){
        teste[] arrayOnibus=GameObject.FindObjectsOfType<teste>();
        Vector3 SpawnPosition = arrayOnibus[Random.Range(0,arrayOnibus.Length)].transform.position;
        SpawnPosition.y = 0;
        GameObject aluno=Instantiate(alunos,SpawnPosition, Quaternion.identity);
        aluno.GetComponent<alunoss>().alunosAndar(destinationPoint.position);
        quantidadeAlunos++;
        GameManager.Instance.IncrementarEstudantes(7);
    }
    

}
