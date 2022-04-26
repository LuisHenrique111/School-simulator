using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game;
using UI;
using Game.Variables;
using Game.Data;
using UnityEngine.AI;
public class SpawnGrid : MonoBehaviour
{
    public static SpawnGrid Instance;
    public IntVariable coin;
    public Tween tween;
    public BuildingData[] objects; 

    private GameObject pendingObject;

    private Vector3 pos;
    
    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;
    public bool canPlace =true;

    public float gridSize;
    public float rotateAmount;
    bool gridOn =true;
    [SerializeField] private Toggle gridToggle;

    void Start(){
        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if(pendingObject != null)
        {
            if(gridOn){
                pendingObject.transform.position = new Vector3(
                    RoundToNearestGrid(pos.x),
                    RoundToNearestGrid(pos.y),
                    RoundToNearestGrid(pos.z)
                );
            }
            else{pendingObject.transform.position = pos;}
            
            if(Input.GetMouseButton(0) && canPlace){
                PlaceObject();
            }
            if(Input.GetKeyDown(KeyCode.R)){
                RotateObject();
            }
        }
    }
    public void PlaceObject(){
        Debug.Log (pendingObject);
        pendingObject.GetComponent<caminhoAluno>().CreateCasa();
        pendingObject = null;
    }
    public void RotateObject(){
        pendingObject.transform.Rotate(Vector3.up,rotateAmount);
    }
    private void FixedUpdate()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit,1000,layerMask))
        {
            
            pos = hit.point;
        }
    }
    public void SelectObject(int index){
        if(coin.Value >= 10){
            pendingObject = Instantiate(objects[index].asset, pos, transform.rotation);
            GameManager.Instance.DiminuirMoedas(10);
            objects[index].spawned = true;
            // GameManager.Instance.AumentarEstudantes(10);
            // GameManager.Instance.AumentarFelicidade(10);
        }else{
            UIVariables.Instance.screenInsufficientMoney.SetActive(true);
            tween.ErroContrProf();
        }
    }
    public void ToggleGrid(){
        if(gridToggle.isOn){
            gridOn = true;
        }else{gridOn =false;}
    } 
    float RoundToNearestGrid(float pos){
        float xDiff = pos % gridSize;
        pos -=xDiff;
        if(xDiff>(gridSize/2)){
            pos +=gridSize;
        }
        return pos ;
    }
}
