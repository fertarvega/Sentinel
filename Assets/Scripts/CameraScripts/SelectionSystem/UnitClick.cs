using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UnitClick : MonoBehaviour
{
    [SerializeField] GraphicRaycaster raycaster;
    PointerEventData pointerEventData;
    [SerializeField] EventSystem eventSystem;

    private Camera MyCam;

    public LayerMask clickable;
    public LayerMask ui;
    public LayerMask ground;

    private void Start(){
        MyCam = Camera.main;
    }

    private void Update(){
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray ray = MyCam.ScreenPointToRay(Input.mousePosition);
            
            pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;
            var results = new List<RaycastResult>();
            raycaster.Raycast(pointerEventData, results);

            if (results.Count > 0){
                // The ray intersects with a UI element
                // Debug.Log("UI element clicked!");
            } else if (Physics.Raycast(ray, out hit)){
                // The ray intersects with a non-UI object
                if(Physics.Raycast(ray, out hit, Mathf.Infinity, clickable)){
                    if (Input.GetKey(KeyCode.LeftShift)){
                        UnitSelections.Instance.ShiftClickSelect(hit.collider.gameObject);
                    }
                    else{
                        UnitSelections.Instance.ClickSelect(hit.collider.gameObject);
                    }
                }
                else{
                    if (!Input.GetKey(KeyCode.LeftShift)){
                        UnitSelections.Instance.DeselectAll();
                    }
                }
            }
        }
    }
}
