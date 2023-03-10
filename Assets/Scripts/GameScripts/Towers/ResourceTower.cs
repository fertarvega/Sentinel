using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTower : MonoBehaviour
{

    private List<string> resources = new List<string>();
    
    private void Start(){
        foreach(GridObject obj in LevelGrid.Instance.GetAdjacentGridObjects(GetComponent<Unit>().GetGridPosition())){
            if(obj.HasAnyUnitResource()){
                resources.Add(obj.GetUnitResource().TypeOfResource);
            }
        }
    }

    public void GetResourcesAmount(){
        foreach(string resource in resources){
            switch(resource){
                case "Gold":
                    ResourceSystem.Instance.goldResource += 1;
                    break;
                case "Stone":
                    ResourceSystem.Instance.stoneResource += 1;
                    break;
                case "Wood":
                    ResourceSystem.Instance.woodResource += 1;
                    break;
                case "Crystal":
                    ResourceSystem.Instance.crystalResource += 1;
                    break;
            }
        }
    }
}
