using UnityEngine.EventSystems;
using UnityEngine;
using System;
public class NewRound : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject spawn;
    private Vector3 worldPos;
    
    void Start(){
        worldPos = new Vector3(500, 0, 500);
    }

    public void OnPointerClick(PointerEventData eventData){
        
        // Instantiate(spawn, worldPos, Quaternion.identity);
    }

}
