using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    public static LevelGrid Instance { get; private set; }

    public GridSystem gridSystem;
    [SerializeField] private Transform gridDebugObjectPrefab;
    public int width = 10;
    public int heigth = 10;
    public float cellSize = 2f;

    public List<Unit> unitList = new List<Unit>();
    public List<UnitResource> unitResourceList = new List<UnitResource>();
    public List<Enemy> enemyList = new List<Enemy>();

    private void Awake() {
        if (Instance != null)
        {
            Debug.LogError("There's more than one LevelGrid! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        gridSystem = new GridSystem(width, heigth, cellSize);
        // gridSystem.CreateDebugObjects(gridDebugObjectPrefab); Activar el prefab
    }

    public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit) {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.AddUnit(unit);
    }

    public List<Unit> GetUnitListAtGridPosition(GridPosition gridPosition){
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.GetUnitList();
    }

    public void RemoveUnitAtGridPosition(GridPosition gridPosition, Unit unit){
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        // gridObject.RemoveUnit(unit);
        // Destroy(unit);
    }

    public void AddUnitResourceAtGridPosition(GridPosition gridPosition, UnitResource unitResource) {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.AddUnitResource(unitResource);
    }

    public List<UnitResource> GetUnitResourceListAtGridPosition(GridPosition gridPosition){
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.GetUnitResourceList();
    }

    public void RemoveUnitResourceAtGridPosition(GridPosition gridPosition, UnitResource unitResource){
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.RemoveUnitResource(unitResource);
        Destroy(unitResource);
    }

    public void UnitMoveGridPosition(Unit unit, GridPosition oldGridPosition, GridPosition newGridPosition){
        // Destroy(unit);
        // RemoveUnitAtGridPosition(oldGridPosition, unit);
        // AddUnitAtGridPosition(newGridPosition, unit);
        // Vector3 OldPos = unit.GetComponent<Transform>().position;
        // unit.GetComponent<Transform>().position = new Vector3(newGridPosition.x, OldPos.y, newGridPosition.z );
    }

    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);

    public List<GridObject> GetAdjacentGridObjects(GridPosition gridPosition) => gridSystem.GetAdjacentGridObjects(gridPosition);
    
    public Vector3 GetWorldPosition(GridPosition gridPosition) => gridSystem.GetWorldPosition(gridPosition);

    public bool IsValidGridPosition(GridPosition gridPosition) => gridSystem.IsValidGridPosition(gridPosition);

    public int GetWidth() => gridSystem.GetWidth();

    public int GetHeight() => gridSystem.GetHeight();

    public float GetCellSize() => gridSystem.GetCellSize();

    public bool HasAnyUnitOnGridPosition(GridPosition gridPosition){
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.HasAnyUnit() || gridObject.HasAnyUnitResource();
    }
}
