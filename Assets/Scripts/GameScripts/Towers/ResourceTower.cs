using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTower : MonoBehaviour
{

    private List<string> resources = new List<string>();
    public int getResourceQuantity = 1;
    
    private void Start(){
        foreach(GridObject obj in LevelGrid.Instance.GetAdjacentGridObjects(GetComponent<Unit>().GetGridPosition())){
            if(obj.HasAnyUnitResource()){
                resources.Add(obj.GetUnitResource().TypeOfResource);
            }
        }

        SumTotalResourcesToCollect();
        
        // InvokeRepeating("GetResourcesAmount", 0f, 3f); // spawn an enemy every 3 second
    }

    public void GetResourcesAmount(){
        foreach(string resource in resources){
            switch(resource){
                case "Gold":
                    ResourceSystem.Instance.goldResource += getResourceQuantity;
                    break;
                case "Stone":
                    ResourceSystem.Instance.stoneResource += getResourceQuantity;
                    break;
                case "Wood":
                    ResourceSystem.Instance.woodResource += getResourceQuantity;
                    break;
                case "Crystal":
                    ResourceSystem.Instance.crystalResource += getResourceQuantity;
                    break;
            }
        }
    }

    public List<string> GetResourcesList(){
        return resources;
    }

    public void SumTotalResourcesToCollect(){
        foreach(string resource in resources){
            switch(resource){
                case "Gold":
                    ResourceSystem.Instance.totalToRecollectGold += 1;
                    break;
                case "Stone":
                    ResourceSystem.Instance.totalToRecollectStone += 1;
                    break;
                case "Wood":
                    ResourceSystem.Instance.totalToRecollectWood += 1;
                    break;
                case "Crystal":
                    ResourceSystem.Instance.totalToRecollectCrystal += 1;
                    break;
            }
         
        }
    }
}
