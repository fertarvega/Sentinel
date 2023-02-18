using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDrag : MonoBehaviour
{
    Camera MyCam;

    [SerializeField]
    RectTransform boxVisual;

    Rect selectionBox;

    Vector2 startPosition;
    Vector2 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        MyCam = Camera.main;
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;
        DrawVisual();
    }

    // Update is called once per frame
    void Update()
    {
        //when click
        if(Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            selectionBox = new Rect();
        }
        //when hold clic
        if(Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
            DrawVisual();
        }
        // when release click
        if(Input.GetMouseButtonUp(0))
        {
            startPosition = Vector2.zero;
            endPosition = Vector2.zero;
            DrawVisual();
            DrawSelection();
            SelectUnits();
        }
    }

    void DrawVisual()
    {
        Vector2 boxStart = startPosition;
        Vector2 boxEnd = endPosition;
        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        
        boxVisual.position = boxCenter;

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x ), Mathf.Abs(boxStart.y - boxEnd.y));

        boxVisual.sizeDelta = boxSize;
    }
    void DrawSelection()
    {
        // do x calculcation
        if(Input.mousePosition.x < startPosition.x)
        {
            // left
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPosition.x;
        }
        else if(Input.mousePosition.x > startPosition.x)
        {
            // rigth
            selectionBox.xMin = startPosition.x;
            selectionBox.xMax = Input.mousePosition.x;
        }
        // do y calculcation
        if(Input.mousePosition.y < startPosition.y)
        {
            // down
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPosition.y;
        }
        else if((Input.mousePosition.y > startPosition.y))
        {
            // up
            selectionBox.yMin = startPosition.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
    }
    void SelectUnits()
    {
        foreach (var unit in UnitSelections.Instance.unitList)
        {
            if(selectionBox.Contains(MyCam.WorldToScreenPoint(unit.transform.position)))
            {
                print("hit: " + unit);
                UnitSelections.Instance.DragSelect(unit);
            }
        }
    }
}
