using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class ImageClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [NonSerialized]
    public bool isHolding = false;
    [NonSerialized]
    public Camera mainCamera;
    [NonSerialized]
    public bool isHovering = false;

    public static List<ImageClick> instances = new List<ImageClick>();

    
    void Start(){
        mainCamera = Camera.main;
    }

    void Awake()
    {
        instances.Add(this); // Add this instance to the list on creation
    }

    void OnDestroy()
    {
        instances.Remove(this); // Remove this instance from the list on destruction
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
    }
}