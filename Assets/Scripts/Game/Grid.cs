using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Data{
    public class Grid : MonoBehaviour
    {
        public new Camera camera;
        
        void Start()
        {
            camera = Camera.main;
        }

        void Update()
        {
            if(Input.GetMouseButtonDown(1))
            {
                GameObject clicked = RaycastCamera(out Vector3 point);
                Debug.Log($"Clicked at: {clicked} {point}");
            }
        }

        public GameObject RaycastCamera(out Vector3 point)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, 20f))
            {
                point = hit.point;
                return hit.collider.gameObject;
            }

            point = Vector3.zero;
            return null;
        }
    }
}
