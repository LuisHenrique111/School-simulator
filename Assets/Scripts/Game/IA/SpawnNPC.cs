using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Variables;
using Game.Variables.Generic;


public class SpawnNPC : MonoBehaviour
{
    public static SpawnNPC Instance;
    public GameObject prefabNpc;
    public IntVariable quatidadeNpc;
    public Transform position;
    public int contador;

    public Mesh mesh;
    public Material material;

    void Start(){
        Instance = this;
    }

    public void SpawnDoNPC(){
        if(contador<quatidadeNpc.Value){
            for(int i = 0; i < (quatidadeNpc.Value - contador); i++){
                //Instantiate(prefabNpc, position.position, position.rotation);
                Factory.CreateNPC(mesh, material, position);
                contador++;
            }
        }
    }
}
