using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridEmptyObject : MonoBehaviour
{
     private GridPosition gridPosition;
     
    private void Start(){
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        // Vector3 worldPos = LevelGrid.Instance.GetWorldPosition(gridPosition);
        // transform.position = new Vector3(worldPos.x, 0, worldPos.z);
        LevelGrid.Instance.AddEmptyObjectAtGridPosition(gridPosition, this);
    }
}
