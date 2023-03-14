using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 45.0f;

    void Update()
    {
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
}