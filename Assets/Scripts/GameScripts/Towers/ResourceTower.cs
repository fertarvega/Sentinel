using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTower : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        foreach(GridObject obj in LevelGrid.Instance.GetAdjacentGridObjects(GetComponent<Unit>().GetGridPosition())){
            Debug.Log(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
