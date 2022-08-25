using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [Header("GridConfig")]
    public int x;
    public int y;
    public float space;
    public GameObject grid;
    public GameObject selected;
    void Start (){
        GenerateGrid();
    }

    void GenerateGrid(){
        for (int iy = 0 ; iy <y; iy++){
            for(int ix = 0 ;ix <x;ix++){
                Instantiate(grid, new Vector3(ix , 0 , iy),Quaternion.identity, transform);
            }
        }
    }
}
