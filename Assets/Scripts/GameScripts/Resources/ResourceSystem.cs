using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSystem : MonoBehaviour
{
    public int goldResource;
    public int stoneResource;
    public int woodResource;
    public int crystalResource;

    public static ResourceSystem Instance { get; private set; }

    private void Awake() {
        if (Instance != null)
        {
            Debug.LogError("There's more than one ResourceSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

}
