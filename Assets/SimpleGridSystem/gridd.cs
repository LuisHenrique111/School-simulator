// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Tilemaps;

// public class gridd : MonoBehaviour
// {
//     // Start is called before the first frame update
//    public static BuildingSystem current;
//    public GridLayout gridLayout;
//    private Grid grid;
//    [SerializeField] private Tilemaps MainTilemap;
//    [SerializeField] private TileBase whiteTile;

//    public GameObject prefab1;
//    public GameObject prefab2;
//    private PlaceableObject objecToPlace;
//    #region  Unity methods
//    private void Awake()
//    {
//     current = this;
//     grid = gridLayout.gameObject.GetComponent<Grid>();
//     #endregion
//     #region  Utils
//     public static Vector3 GetMouseWorldPosition(){
//         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//         if(Physics.Raycast(ray, out RaycastHit raycastHit)){
//             return raycastHit.point;
//         }
//         else
//         {
//             {
//                 return Vector3.zero;
//             }
//         }
//     public Vector3 SnapCoordinateToGrid(Vector3 position)
//     {
//         Vector3Int cellPos = gridLayout.WorldToCell(position);
//         position = grid.GetCellCenterWorld(cellPos);
//         return position;
//     }    
//     }
//    }
//    #endregion
// }
