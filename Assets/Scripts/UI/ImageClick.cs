using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class ImageClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [NonSerialized]
    public bool isHolding = false;
    public GameObject enemyPrefab;
    private Camera mainCamera;
    private bool isHovering = false;

    void Start(){
        mainCamera = Camera.main;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {   
        isHolding = false;
        if(isHovering)return;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // Declare a variable to store the hit information
        RaycastHit hit;

        // Cast the ray and check if it hits an object
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 worldPos = LevelGrid.Instance.GetWorldPosition(LevelGrid.Instance.GetGridPosition(hit.point));
            // Print the world position of the mouse
            // Debug.Log("Mouse position: " + worldPos);
            Instantiate(enemyPrefab, worldPos, Quaternion.identity);
        }
        
    }
    
    private void Update()
    {
        
    }
}