using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystemVisual : MonoBehaviour
{
    public static GridSystemVisual Instance { get; private set; }

    [SerializeField] Transform gridSystemVisualSinglePrefab;

    private GridSystemVisualSingle[,] gridSystemVisualSingleArray;

    private void Start(){
        if (Instance != null)
        {
            Debug.LogError("There's more than one GridSystemVisual! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        gridSystemVisualSingleArray = new GridSystemVisualSingle[
            LevelGrid.Instance.GetWidth(),
            LevelGrid.Instance.GetHeight()
        ];

        for(int x = 0; x < LevelGrid.Instance.GetWidth(); x++){
            for(int z= 0; z < LevelGrid.Instance.GetHeight(); z++){
                GridPosition position = new GridPosition(x, z);

                Transform gridSystemVisualSingleTransform =
                    Instantiate(gridSystemVisualSinglePrefab, LevelGrid.Instance.GetWorldPosition(position), Quaternion.identity);

                gridSystemVisualSingleArray[x, z] = gridSystemVisualSingleTransform.GetComponent<GridSystemVisualSingle>();
            }
        }

        HideAllGridPosition();
    }

    private void Update(){
        // UpdateVisualGrid();
    }

    public void HideAllGridPosition(){
        for(int x = 0; x < LevelGrid.Instance.GetWidth(); x++){
            for(int z= 0; z < LevelGrid.Instance.GetHeight(); z++){
                gridSystemVisualSingleArray[x, z].Hide();
            }
        }
    }

    public void ShowGridPositionList(List<GridPosition> gridPositionList){
        foreach(GridPosition gridVisualPosition in gridPositionList){
            gridSystemVisualSingleArray[gridVisualPosition.x, gridVisualPosition.z].Show();
        }
    }

    public void UpdateVisualGrid(){
        HideAllGridPosition();
        // Unit unitSelected = UnitSelectionSystem.Instance.GetSelectedUnit();
        ShowGridPositionList(GetValidActionGridPositionList());
    }

        public List<GridPosition> GetValidActionGridPositionList(){
        List<GridPosition> validGridPositionList = new List<GridPosition>();

        // GridPosition unitGridPosition = unit.GetGridPosition();

        for(int x = -LevelGrid.Instance.GetWidth(); x <= LevelGrid.Instance.GetWidth(); x++){
            for(int z = -LevelGrid.Instance.GetHeight(); z <= LevelGrid.Instance.GetHeight(); z++){
                GridPosition offsetGridPosition = new GridPosition(x, z);
                GridPosition testGridPosition = offsetGridPosition;

                if(!LevelGrid.Instance.IsValidGridPosition(testGridPosition)){
                    continue;
                }

                // if(unitGridPosition == testGridPosition){
                //     continue;
                // }

                if(LevelGrid.Instance.HasAnyUnitOnGridPosition(testGridPosition)){
                    continue;
                }

                validGridPositionList.Add(testGridPosition);
            }
        }

        return validGridPositionList;
    }
}
