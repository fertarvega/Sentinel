using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class EnemyMovement : MonoBehaviour
{
    [NonSerialized]
    public bool canMove = false;
    private Unit unit;
    private Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        unit = GetComponent<Unit>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != newPos){
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime / 1);
        }
        if(canMove){
            // MoveRigth();
            // MoveLeft();
            // MoveDown();
            Move(2f,"front");
        }
    }
    void Move(float cells, string direction)
    {
        Vector3 _newPos = transform.position;
        float amount = LevelGrid.Instance.GetCellSize() * cells;

        switch (direction)
        {
            case "front":
                _newPos.z += amount;
                break;
            case "back":
                _newPos.z -= amount;
                break;
            case "left":
                _newPos.x -= amount;
                break;
            case "right":
                _newPos.x += amount;
                break;
            default:
                Debug.LogError("Invalid direction: " + direction);
                return;
        }

        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(_newPos);

        if (LevelGrid.Instance.IsValidGridPosition(newGridPosition) && !LevelGrid.Instance.HasAnyUnitOnGridPosition(newGridPosition))
        {
            newPos = _newPos;
            canMove = false;
        }
    }
}
