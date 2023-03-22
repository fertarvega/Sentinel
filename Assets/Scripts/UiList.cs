using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiList : MonoBehaviour
{
    public static UiList Instance { get; private set; }
    [SerializeField] public TextMeshProUGUI txtGold;
    [SerializeField] public TextMeshProUGUI txtWood;
    [SerializeField] public TextMeshProUGUI txtStone;
    [SerializeField] public TextMeshProUGUI txtCrystal;
    [SerializeField] public TextMeshProUGUI txtRound;
    [SerializeField] public Button buttonFinishRound;
    [SerializeField] public Button buttonStartWave;
    [SerializeField] public GameObject tutorialMenu; 

    private void Awake() {
        if (Instance != null){
            Debug.LogError("There's more than one UiList! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Update(){
        txtGold.text = ResourceSystem.Instance.goldResource.ToString();
        txtWood.text = ResourceSystem.Instance.woodResource.ToString();
        txtStone.text = ResourceSystem.Instance.stoneResource.ToString();
        txtCrystal.text = ResourceSystem.Instance.crystalResource.ToString();
    }

    public void ActivateAndDeactivateTutorial(){
        if(tutorialMenu.activeSelf){
            tutorialMenu.SetActive(false);
        } else {
            tutorialMenu.SetActive(true);
        }
    }
}
