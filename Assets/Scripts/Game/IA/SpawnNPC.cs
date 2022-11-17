using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Variables;
using Game.Variables.Generic;
using Unity.Mathematics;

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
                //Factory.CreateNPC(mesh, material, position);
                Instantiate(prefabNpc,position.position, quaternion.identity);
                contador++;
            }
        }
    }
}
