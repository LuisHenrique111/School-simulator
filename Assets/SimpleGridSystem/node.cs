// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class node : MonoBehaviour
// {
//    public Color houverColor;
//    private GameObject cubo;
//    private Renderer rend;
//    private Color startColor;
//    public Vector3 positionOffset;
//     void Start()
//     {
//         rend = GetComponent<Renderer>();
//         startColot = rend.material.color;
//     }
//     void OnMouseDown (){
//         if(cubo !=null)
//         Debug.Log("teste");
//         return;
//     }
//     GameObject cuboToBuild = BuildManager.instance.GetcuboToBuild();
//     Instantiate(cuboToBuild, transform.position + positionOffset,transform.rotation);
//     void OnMouseEnter(){
//         rend.material.color = hoverColor;
//     }
//     void OnMouseExit()
//     {
//         rend.material.color = startColor;
//     }
// }
