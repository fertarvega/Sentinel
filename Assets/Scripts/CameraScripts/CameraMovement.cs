using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float rotationSpeed = 45.0f;
    [SerializeField] private float zoomSpeed = 10f;
    [SerializeField] private float minZoom = 5f;
    [SerializeField] private float maxZoom = 60f;
    private Camera mainCamera;

   private void Start(){
        mainCamera = Camera.main;
    }

    void Update()
    {
        HandleMovement();
        HandleZoom();
    }

    private void HandleMovement(){
        float yPos = transform.position.y;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Vector3 currentRotation = transform.eulerAngles;
            currentRotation.y -= rotationSpeed * Time.deltaTime;
            transform.eulerAngles = currentRotation;
        }
        if (Input.GetKey(KeyCode.E))
        {
            Vector3 currentRotation = transform.eulerAngles;
            currentRotation.y += rotationSpeed * Time.deltaTime;
            transform.eulerAngles = currentRotation;
        }
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }

    private void HandleZoom(){
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float newZoom = mainCamera.fieldOfView + (-scroll) * zoomSpeed;

        // Limit the zoom within the min and max values
        newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);

        // Apply the new zoom level to the camera
        mainCamera.fieldOfView = newZoom;
    }
}