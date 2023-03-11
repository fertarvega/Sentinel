using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : ImageClick
{
    public string message;

public override void OnPointerEnter(PointerEventData eventData)
{
    if (!TooltipManager.Instance.IsTooltipVisible())
    {
        TooltipManager.Instance.SetAndShowTooltip(message);
    }
}


public override void OnPointerExit(PointerEventData eventData)
{
    if (TooltipManager.Instance.IsTooltipVisible())
    {
        TooltipManager.Instance.HideTooltip();
    }
}
}
