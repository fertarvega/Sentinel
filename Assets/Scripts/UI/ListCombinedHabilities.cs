using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCombinedHabilities : MonoBehaviour
{
    public static ListCombinedHabilities Instance { get; private set; }

    [SerializeField] public List<ParticleSystem> listCombinedHabilities;

    private void Awake() {
        if (Instance != null){
            Debug.LogError("There's more than one ListCombinedHabilities! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
}
