using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class CreateEnemyUI : ImageClick
{
    [SerializeField] private Unit unit;
    [NonSerialized]
    private Unit unitHovering;

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        if(isHovering)return;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        // Declare a variable to store the hit information
        RaycastHit hit;
        // Cast the ray and check if it hits an object
        if (Physics.Raycast(ray, out hit)){
            GridPosition gridPosition = LevelGrid.Instance.GetGridPosition(hit.point);
            if(LevelGrid.Instance.IsValidGridPosition(gridPosition) && !LevelGrid.Instance.HasAnyUnitOnGridPosition(gridPosition)){
                Vector3 worldPos = LevelGrid.Instance.GetWorldPosition(gridPosition);
                // Print the world position of the mouse
                Unit newUnit = Instantiate(unit, worldPos, Quaternion.identity);
                LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, newUnit);
                newUnit.GetComponent<EnemyMovement>().canMove=true;
            }
        }
    }
    
    public override void OnPointerDown(PointerEventData eventData)
    {
        unitHovering = Instantiate(unit, new Vector3(-100,-100,0), Quaternion.identity);
        base.OnPointerDown(eventData);
        
    }

    private void Update(){
        if(isHolding){
            Vector3 mouse = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                unitHovering.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
            }
        } else if(unitHovering && !isHolding) Destroy(unitHovering.gameObject);
    }
}
