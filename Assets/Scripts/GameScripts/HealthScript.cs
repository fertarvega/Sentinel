using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public float Health = 100f;
    private float MaxHealth = 100f;
    private Slider HealthBar;

private void Start() {
    // Iterate over the children of the GameObject
    foreach (Transform child in transform) {
        // Check if the child has a Canvas component
        Canvas canvas = child.GetComponent<Canvas>();
        if (canvas != null) {
            // Find the Slider component in the Canvas
            HealthBar = canvas.GetComponentInChildren<Slider>();
            break; // Stop iterating after finding the first Canvas
        }
    }
}

    private void Update() {
        if(HealthBar != null){
            HealthBar.value = Health;
        }
    }
    public void healDamage(float heal){

        Health+=heal;
        if(Health > MaxHealth){
            Health = MaxHealth;
        }
    }
    public void takeDamage(float damage){
        if(Health >= 0){
            Health-=damage;
            Debug.Log(Health);
        }
    }
}
