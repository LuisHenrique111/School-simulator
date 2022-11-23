using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
  public static CameraController instance;
  public Transform cameraTransform;
  public float speed = 1.0f;
  public float movimentTime = 1.0f;
  public float rotationValue = 1.0f;
  public Vector3 zoomValue = new Vector3(0.0f, 5f, 0.0f);

  Vector3 newPosition;
  Quaternion newRotation;
  Vector3 newZoom;

  Vector3 mousePosition;
  Vector3 dragStartPosition;
  Vector3 dragEndPosition;
  Vector3 rotateStartPosition;
  Vector3 rotateEndPosition;

  


  
  // Start is called before the first frame update
  void Start()
  {
    instance = this;
    transform.position = ClampCamera(transform.position);

    newPosition = transform.position;
    
    
    newRotation = transform.rotation;
    newZoom = cameraTransform.localPosition;
    
  }

  // Update is called once per frame
  void Update()
  {


    MouseMove(); 
    MovimentKeys();
    transform.position = ClampCamera(transform.position);
    
    
    
    
    
  }

  private Vector3 ClampCamera(Vector3 target)
  {
    float clampX = Mathf.Clamp(target.x,-450 ,275);
    float clampY = Mathf.Clamp(target.y, -50,80);
    float clampZ = Mathf.Clamp(target.z,0,400);
    

    return new Vector3(clampX,clampY,clampZ);
  }

  

  public void MouseMove()
  {
    if(Input.GetMouseButtonDown(1))
    {
      Plane plane = new Plane(Vector3.up, Vector3.zero);

      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      
      if(plane.Raycast(ray, out float enter))
      {
        dragStartPosition = ray.GetPoint(enter);
      }

    }
    if(Input.GetMouseButton(1))
    {
      Plane plane = new Plane(Vector3.up, Vector3.zero);

      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      
      if(plane.Raycast(ray, out float enter))
      {
        dragEndPosition = ray.GetPoint(enter);
        newPosition = transform.position + (dragEndPosition - dragStartPosition);
      }
    }
    if(Input.GetMouseButtonDown(2))
    {
      rotateStartPosition = Input.mousePosition;
    }
    if(Input.GetMouseButton(2))
    {
      rotateEndPosition = Input.mousePosition;
      
      Vector3 rotate = rotateEndPosition - rotateStartPosition;

      rotateStartPosition = rotateEndPosition;

      newRotation *= Quaternion.Euler(Vector3.up * (-rotate.x/10f));
    }


    if(Input.mouseScrollDelta.y != 0)
    {
      newZoom -= zoomValue * Input.mouseScrollDelta.y;
    }
    cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movimentTime);
  }

  public void MovimentKeys()
  {
    if (Input.GetKey(KeyCode.W))
    {
        newPosition += (transform.forward * speed);  
    }
    if (Input.GetKey(KeyCode.S))
    {
        newPosition += (transform.forward * -speed);
    }
    if (Input.GetKey(KeyCode.A))
    {
        newPosition += (transform.right * -speed);  
    }
    if (Input.GetKey(KeyCode.D))
    {
        newPosition += (transform.right * speed);
    }
    if (Input.GetKey(KeyCode.Q))
    {
        newRotation *= Quaternion.Euler(Vector3.up * rotationValue);  
    }
    if (Input.GetKey(KeyCode.E))
    {
        newRotation *= Quaternion.Euler(Vector3.up * -rotationValue);  
    }
    if (Input.GetKey(KeyCode.Z))
    {
      
      newZoom += zoomValue;
      
      
    }
    if (Input.GetKey(KeyCode.X))
    {
      
      newZoom -= zoomValue;  
        
    }
    
    transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movimentTime);
    transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, movimentTime);
    cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movimentTime);
    //
    
  }


}
