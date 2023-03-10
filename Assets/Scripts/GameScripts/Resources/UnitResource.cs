using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitResource : MonoBehaviour
{
    // [SerializeField] public List<string> TypeOfResource = new List<string>{"Gold", "Stone"};
    [SerializeField] public string TypeOfResource;
    private GridPosition gridPosition;

    private void Start(){
        LevelGrid.Instance.unitResourceList.Add(this);

        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        Vector3 worldPos = LevelGrid.Instance.GetWorldPosition(gridPosition);
        transform.position = new Vector3(worldPos.x, 0.5f, worldPos.z);
        LevelGrid.Instance.AddUnitResourceAtGridPosition(gridPosition, this);
    }

    private void Update(){

    }

    private void OnDestroy() {
        LevelGrid.Instance.unitResourceList.Remove(this);
    }

    public GridPosition GetGridPosition(){
        return gridPosition;
    }

}
