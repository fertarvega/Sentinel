using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSystem : MonoBehaviour
{
    public int goldResource = 0;
    public int stoneResource = 0;
    public int woodResource = 0;
    public int crystalResource = 0;

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
