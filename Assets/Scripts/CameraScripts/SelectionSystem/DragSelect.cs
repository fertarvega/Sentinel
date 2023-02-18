using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSelect : MonoBehaviour
{
    private bool isDragSelect = false;

    private Vector3 mousePositionInitial;
    private Vector3 mousePositionEnd;
    public RectTransform selectionBox;

    public ImageClick UiClicking;

    void Update(){
        if(Input.GetMouseButtonDown(0) ){
            mousePositionInitial = Input.mousePosition;
            isDragSelect = false;
        }

        if(Input.GetMouseButton(0)&& !UiClicking.isHolding){
            if(!isDragSelect && (mousePositionInitial - Input.mousePosition).magnitude > 30){
                isDragSelect = true;
            }
            
            if(isDragSelect){
                mousePositionEnd = Input.mousePosition;
                UpdateSelectionBox();
            }
        }

        if(Input.GetMouseButtonUp(0)){
            if(isDragSelect){
                isDragSelect = false;
                UpdateSelectionBox();
                SelectObjects();
            }
        }
    }

    void UpdateSelectionBox(){
        selectionBox.gameObject.SetActive(isDragSelect);

        float width = mousePositionEnd.x - mousePositionInitial.x;
        float height = mousePositionEnd.y - mousePositionInitial.y;

        selectionBox.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));

        selectionBox.anchoredPosition = new Vector2(mousePositionInitial.x, mousePositionInitial.y) + new Vector2(width/2, height/2);
    }

    void SelectObjects(){
        Vector2 minValue = selectionBox.anchoredPosition - (selectionBox.sizeDelta / 2);
        Vector2 maxValue = selectionBox.anchoredPosition + (selectionBox.sizeDelta / 2);

        GameObject[] selectableObjs = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject selectableObj in selectableObjs){
            Vector3 objScreenPos = Camera.main.WorldToScreenPoint(selectableObj.transform.position);

            if(objScreenPos.x > minValue.x && objScreenPos.x < maxValue.x && objScreenPos.y > minValue.y && objScreenPos.y < maxValue.y){
                UnitSelections.Instance.DragSelect(selectableObj);
            }
        }
    }
}
