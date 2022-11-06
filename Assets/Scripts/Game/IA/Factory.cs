using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public static GameObject CreateNPC(Mesh mesh, Material material, Transform pos){
        GameObject obj = new GameObject();
        obj.AddComponent<MeshRenderer>();
        obj.AddComponent<MeshFilter>();
        obj.GetComponent<MeshFilter>().mesh = mesh;
        obj.GetComponent<MeshRenderer>().material = material;
        obj.AddComponent<CapsuleCollider>();
        obj.GetComponent<CapsuleCollider>().isTrigger = true;
        obj.AddComponent<Students>();
        obj.transform.position = pos.transform.position;
        return obj;

    }
}
