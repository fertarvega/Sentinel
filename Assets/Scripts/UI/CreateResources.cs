using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateResources : ImageClick
{
    [SerializeField] private Unit unit;
    private Unit unitHovering;

    public override void OnPointerDown(PointerEventData eventData){
        base.OnPointerDown(eventData);
        unitHovering = Instantiate(unit, new Vector3(-100,-100,0), Quaternion.identity);
    }

    public override void OnPointerUp(PointerEventData eventData){   
        base.OnPointerUp(eventData);

        if(isHovering) return;

        if(!ShopSystem.Instance.CanBuyResourceTower()) return;

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
                ShopSystem.Instance.BuyResourceTower();
                LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, newUnit);
                newUnit.transform.GetChild(0).gameObject.SetActive(false);

                GridSystemVisual.Instance.HideAllGridPosition();
            }
        }
    }
    
    private void Update(){
        if(isHolding){
            unitHovering.GetComponent<AudioSource>().enabled = false;
            Vector3 mouse = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)){

                GridPosition gridPosition = LevelGrid.Instance.GetGridPosition(hit.point);
                Vector3 worldPos = LevelGrid.Instance.GetWorldPosition(gridPosition);
                unitHovering.transform.position= new Vector3(worldPos.x, 1, worldPos.z);
                GridSystemVisual.Instance.ShowGridPositionList(GridSystemVisual.Instance.GetValidActionGridPositionList());
            }
        } else if(unitHovering && !isHolding) Destroy(unitHovering.gameObject);
    }
}
