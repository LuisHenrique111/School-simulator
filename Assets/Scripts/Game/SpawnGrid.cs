using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game;
using UI;
using Game.Variables;
using Game.Data;
using UnityEngine.AI;
using TMPro;
public class SpawnGrid : MonoBehaviour
{
    public GameObject selectedObject;
    public TextMeshProUGUI objNameText;
    public static SpawnGrid Instance;
    public IntVariable coin;
    public Tween tween;
    private GameObject objectCasa;
    private Vector3 pos;  
    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;
    public bool canPlace =true;
   

    public float gridSize;
    public float rotateAmount;
    bool gridOn =true;
    public int raioGrid;
    [SerializeField] private Toggle gridToggle;

    void Start(){
        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if(objectCasa != null)
        {
            if(gridOn){
                objectCasa.transform.position = new Vector3(
                    RoundToNearestGrid(pos.x),
                    RoundToNearestGrid(pos.y),
                    RoundToNearestGrid(pos.z)
                );
            }
            else{objectCasa.transform.position = pos;}
            
            if(Input.GetKeyDown(KeyCode.Return) && canPlace){
                PlaceObject();
            }
            if(Input.GetKeyDown(KeyCode.R)){
                RotateObject();
            }
            if(Input.GetKeyDown(KeyCode.X)){
                Delete();
            }
        }
    }
    public void PlaceObject(){
        Debug.Log (objectCasa);
        objectCasa.GetComponent<caminhoAluno>().CreateCasa();
        objectCasa = null;
    }
    public void RotateObject(){
        objectCasa.transform.Rotate(Vector3.up,rotateAmount);
    }
    private void FixedUpdate()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit,raioGrid,layerMask))
        {
            
            pos = hit.point;
        }
    }
    public void SelectObject(int index){
        if(coin.Value >= 10){
            objectCasa = Instantiate(GameController.Instance.building[index].asset, pos, transform.rotation);
            GameManager.Instance.DiminuirMoedas(GameController.Instance.building[index].price);
            GameController.Instance.building[index].spawned = true;
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
    private void Deselect (){
        selectedObject.GetComponent<Outline>().enabled = false;
        selectedObject = null;
    }
    public void Delete(){
        GameObject objectCasa = selectedObject;
        Deselect();
        Destroy(objectCasa);
    }
}
