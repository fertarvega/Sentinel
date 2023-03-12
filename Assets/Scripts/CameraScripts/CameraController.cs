using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 zoomAmount;
    public Transform cameraTransform;

    public float movementTime;
    public float normalSpeed;
    public float fastSpeed;
    public float normalRotation;
    public float fastRotation;

    private float rotationAmount;
    private float movementSpeed;

    private Vector3 rotateStartPosition;
    private Vector3 rotateCurrentPosition;
    
    private Quaternion newRotation;
    private Vector3 dragStartPosition;
    private Vector3 dragCurrentPosition;
    private Vector3 newPosition;
    private Vector3 newZoom;

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
        // HandleMouseInput();
    }
    void HandleMouseInput(){
        if(Input.mouseScrollDelta.y != 0)
        {
            newZoom += Input.mouseScrollDelta.y * zoomAmount;   
        }

        if(Input.GetMouseButtonDown(1))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if(plane.Raycast(ray, out entry))
            {
                dragStartPosition = ray.GetPoint(entry);   
            }
        }
        if(Input.GetMouseButton(1))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if(plane.Raycast(ray, out entry))
            {
                dragCurrentPosition = ray.GetPoint(entry);

                newPosition = transform.position + dragStartPosition - dragCurrentPosition;   
            }
        }
        if(Input.GetMouseButtonDown(2))
        {
            rotateStartPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(2))
        {
            rotateCurrentPosition = Input.mousePosition;
            
            Vector3 difference = rotateStartPosition - rotateCurrentPosition;
            
            rotateStartPosition = rotateCurrentPosition;

            newRotation *= Quaternion.Euler(Vector3.up * (-difference.x/5f));
        }
    } 

    void HandleMovementInput()
    {
                Vector3 inputMoveDir = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            inputMoveDir.z = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDir.z = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDir.x = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDir.x = +1f;
        }

        float moveSpeed = 10f;

        Vector3 moveVector = transform.forward * inputMoveDir.z + transform.right * inputMoveDir.x;
        transform.position += moveVector * moveSpeed * Time.deltaTime;
        // movementSpeed = Input.GetKey(KeyCode.LeftShift) ? fastSpeed : normalSpeed;

        // rotationAmount = Input.GetKey(KeyCode.LeftShift) ? fastRotation : normalRotation;
        
        // if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        // {
        //     newPosition += (transform.forward * movementSpeed);
        // }
        // if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        // {
        //     newPosition += (transform.forward * -movementSpeed);
        // }
        // if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        // {
        //     newPosition += (transform.right * -movementSpeed);
        // }
        // if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        // {
        //     newPosition += (transform.right * movementSpeed);
        // }
        // if(Input.GetKey(KeyCode.Q))
        // {
        //     newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        // }
        // if(Input.GetKey(KeyCode.E))
        // {
        //     newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        // }
        
        // if(Input.GetKey(KeyCode.F))
        // {
        //     newZoom -= zoomAmount;
        // }
        // if(Input.GetKey(KeyCode.R))
        // {
        //     newZoom += zoomAmount;
        // }

        // transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);

        // transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        
        // cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
    }
}
