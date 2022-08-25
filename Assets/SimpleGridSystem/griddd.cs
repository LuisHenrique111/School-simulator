using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class griddd : MonoBehaviour
{
    [SerializeField]private int height;
    [SerializeField]private Transform cube;
    [SerializeField]private Transform grid;
    
   
    void Update()
    {
        Vector3 quadPos = Vector3.up * height;
        grid.position = quadPos;
    }
    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,1000f))
        {
            Vector3 tilePos = new Vector3(Mathf.RoundToInt(hit.point.x), height, Mathf.RoundToInt(hit.point.z));
            if(hit.collider != null)
            {
                cube.position = tilePos;
            }
        }
    }
}
