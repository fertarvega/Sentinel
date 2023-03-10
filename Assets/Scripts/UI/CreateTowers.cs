using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateTowers : ImageClick
{
    [SerializeField] private Unit unit;
    private Unit unitHovering;

     public override void OnPointerEnter(PointerEventData eventData){
        base.OnPointerEnter(eventData);
    }

    public override void OnPointerExit(PointerEventData eventData){
        base.OnPointerExit(eventData);
    }

    public override void OnPointerDown(PointerEventData eventData){
        base.OnPointerDown(eventData);
        unitHovering = Instantiate(unit, new Vector3(-100,-100,0), Quaternion.identity);
    }

    public override void OnPointerUp(PointerEventData eventData){   
        base.OnPointerUp(eventData);

        if(isHovering) return;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // Declare a variable to store the hit information
        RaycastHit hit;

        // Cast the ray and check if it hits an object
        if (Physics.Raycast(ray, out hit)){
            GridPosition gridPosition = LevelGrid.Instance.GetGridPosition(hit.point);
            if(LevelGrid.Instance.IsValidGridPosition(gridPosition) && !LevelGrid.Instance.HasAnyUnitOnGridPosition(gridPosition)){
                Vector3 worldPos = LevelGrid.Instance.GetWorldPosition(gridPosition);
                worldPos = new Vector3(worldPos.x, 0.5f, worldPos.z);
                Unit newUnit = Instantiate(unit, worldPos, Quaternion.identity);
                LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, newUnit);
            }
        }
    }
    
    private void Update(){
        if(isHolding){
            Vector3 mouse = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)){
                unitHovering.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
            }
        } else if(unitHovering && !isHolding) Destroy(unitHovering.gameObject);
    }
}
