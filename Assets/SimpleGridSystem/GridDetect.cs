using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDetect : MonoBehaviour
{
    // Start is called before the first frame update
    private Grid grid;
    void Start()
    {
        grid = FindObjectOfType<Grid>();
    }

    // Update is called once per frame
    private void OnMouseOver(){
        grid.selected.transform.position = transform.position;
    }
    void Update()
    {
        
    }
}
