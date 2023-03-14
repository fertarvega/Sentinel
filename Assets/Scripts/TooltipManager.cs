using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager Instance;

    public GameObject tooltipPrefab;
    private GameObject currentTooltip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update() {
        if (currentTooltip != null){
            currentTooltip.transform.position = Input.mousePosition;
        }
    }

    public void SetAndShowTooltip(string message)
    {
        if (currentTooltip == null)
        {
            // currentTooltip = Instantiate(tooltipPrefab, transform);
        }
        // currentTooltip.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = message;
        // currentTooltip.SetActive(true);
    }

    public void HideTooltip()
    {
        if (currentTooltip != null)
        {
            // currentTooltip.SetActive(false);
        }
    }

    public bool IsTooltipVisible()
    {
        return (currentTooltip != null && currentTooltip.activeSelf);
    }
}
