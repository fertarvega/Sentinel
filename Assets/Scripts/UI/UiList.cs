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
    [SerializeField] public GameObject combinationsMenu;
    [SerializeField] public TextMeshProUGUI notEnoughResources;

    private Animator animator;
    private float timer = 0f;
    private bool flagTimer = false;

    private void Awake() {
        if (Instance != null){
            Debug.LogError("There's more than one UiList! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        animator = notEnoughResources.GetComponent<Animator>(); 
    }

    private void Update(){
        txtGold.text = ResourceSystem.Instance.goldResource.ToString() + " (+"+ResourceSystem.Instance.totalToRecollectGold.ToString()+")";
        txtWood.text = ResourceSystem.Instance.woodResource.ToString()+ " (+"+ResourceSystem.Instance.totalToRecollectWood.ToString()+")";
        txtStone.text = ResourceSystem.Instance.stoneResource.ToString()+ " (+"+ResourceSystem.Instance.totalToRecollectStone.ToString()+")";
        txtCrystal.text = ResourceSystem.Instance.crystalResource.ToString()+ " (+"+ResourceSystem.Instance.totalToRecollectCrystal.ToString()+")";

        if(flagTimer){
            timer += Time.deltaTime;
            if(timer >= 0.75f){
                flagTimer = false;
                timer = 0f;
                notEnoughResources.gameObject.SetActive(false); // Deactivate the object
            }
        }
    }

    public void ActivateAndDeactivateTutorial(){
        if(tutorialMenu.activeSelf){
            tutorialMenu.SetActive(false);
        } else {
            tutorialMenu.SetActive(true);
        }
    }

    public void ActivateAndDeactivateCombinations(){
        if(combinationsMenu.activeSelf){
            combinationsMenu.SetActive(false);
        } else {
            tutorialMenu.SetActive(false);
            combinationsMenu.SetActive(true);
        }
    }

    public void ActivateNotEnoughResources(){
        flagTimer = true;
        notEnoughResources.gameObject.SetActive(true);
        animator.Play("Zoom_Text"); // Play the animation
        // StartCoroutine(PlayAnimationAndWait());
    }

    private IEnumerator PlayAnimationAndWait(){
        Animator animator = notEnoughResources.GetComponent<Animator>(); 
        animator.Play("Zoom_Text"); // Play the animation
        notEnoughResources.gameObject.SetActive(false); // Deactivate the object
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length); // Wait for the animation to finish
    }
}
