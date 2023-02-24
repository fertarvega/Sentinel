using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScript : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 currentPos;
    private bool isSelecting;
    private List<Transform> selectedTransforms = new List<Transform>();
    public Camera mainCamera;

    private void Start()
    {

    }

    private void OnGUI()
    {
        if (isSelecting)
        {
            // Create a rectangle from the startPos and currentPos
            Rect rect = GetScreenRect(startPos, currentPos);

            // Draw the selection rectangle
            GUI.color = Color.red;
            GUI.Box(rect, new GUIContent());
        }
    }

    private void Update()
    {
        // Check for left mouse button down
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            isSelecting = true;
        }

        // Check for left mouse button up
        if (Input.GetMouseButtonUp(0))
        {
            isSelecting = false;
            selectedTransforms.Clear();
        }

        // Store current mouse position
        if (isSelecting)
        {
            currentPos = Input.mousePosition;
            SelectObjects();
        }
    }

    private void SelectObjects()
    {
        Vector3 start = mainCamera.ScreenToWorldPoint(startPos);
        Vector3 end = mainCamera.ScreenToWorldPoint(currentPos);

        // Get all objects within selection area
        Collider2D[] colliders = Physics2D.OverlapAreaAll(start, end);

        // Store all transforms within selection area
        foreach (Collider2D collider in colliders)
        {
            Transform transform = collider.transform;
            if (!selectedTransforms.Contains(transform))
            {
                selectedTransforms.Add(transform);
            }
        }
    }

    private Rect GetScreenRect(Vector3 screenPosition1, Vector3 screenPosition2)
    {
        // Get screen coordinates of rectangle
        screenPosition1.y = Screen.height - screenPosition1.y;
        screenPosition2.y = Screen.height - screenPosition2.y;
        Vector3 topLeft = Vector3.Min(screenPosition1, screenPosition2);
        Vector3 bottomRight = Vector3.Max(screenPosition1, screenPosition2);

        // Create rectangle
        return Rect.MinMaxRect(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y);
    }

    private void DrawRect(Rect rect, Color color)
    {
        // Draw selection rectangle
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, color);
        texture.Apply();
        GUI.skin.box.normal.background = texture;
        GUI.Box(rect, "", new GUIStyle());
    }
}