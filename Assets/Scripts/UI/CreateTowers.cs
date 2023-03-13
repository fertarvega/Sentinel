using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateTowers : ImageClick
{
    [SerializeField] private Unit unit;
    private Unit unitHovering;
    [SerializeField] private GameObject cube;

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
                cube.SetActive(false);
                cube.transform.position = new Vector3(10, -10, 10);
                GridSystemVisual.Instance.HideAllGridPosition();
            }
        }
    }
    
    private void Update(){
        if(isHolding){
            unitHovering.GetComponent<AudioSource>().enabled = false;
            cube.SetActive(true);
            Vector3 mouse = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            unitHovering.transform.GetChild(0).gameObject.SetActive(false);
            if (Physics.Raycast(ray, out hit)){

                unitHovering.transform.position = new Vector3(hit.point.x, 3, hit.point.z);
                GridPosition gridPosition = LevelGrid.Instance.GetGridPosition(hit.point);
                Vector3 worldPos = LevelGrid.Instance.GetWorldPosition(gridPosition);
                cube.transform.position = worldPos;
                GridSystemVisual.Instance.ShowGridPositionList(GridSystemVisual.Instance.GetValidActionGridPositionList());
            }
        } else if(unitHovering && !isHolding) Destroy(unitHovering.gameObject);
    }
}
