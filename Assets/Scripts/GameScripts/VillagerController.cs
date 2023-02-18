using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerController : MonoBehaviour
{
    public bool Selected { get; set; }

    // Color for selected villager
    public Color selectedColor = Color.yellow;

    // Original color of the villager
    private Color originalColor;

    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
    }
    private void Update()
    {
        renderer.material.color = Selected ? selectedColor : originalColor;
        if (Selected)
        {
            // Move the villager to the target position on mouse click
            if (Input.GetMouseButtonDown(1))
            {
                // Cast a ray from the mouse position in screen space to the scene
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // Check if the ray hit any collider on the ground layer
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    transform.position = hit.point;
                }
            }
        }
    }
}