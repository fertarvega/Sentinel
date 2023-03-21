using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public int health = 100;
    // private int MaxHealth = 100;
    [SerializeField] private HealthBar HealthBar;

    private void Awake(){
        HealthBar.SetMaxHealth(health);
    }

private void Start() {
    // Iterate over the children of the GameObject
    foreach (Transform child in transform) {
        // Check if the child has a Canvas component
        Canvas canvas = child.GetComponent<Canvas>();
        if (canvas != null) {
            // Find the Slider component in the Canvas
            // HealthBar = canvas.GetComponentInChildren<Slider>();
            break; // Stop iterating after finding the first Canvas
        }
    }
}

    private void Update() {
        if(HealthBar != null){
            HealthBar.SetHealth(health);
        }
        if(health <= 0) Destroy(gameObject);
    }
    // public void healDamage(float heal){

    //     health+=heal;
    //     if(health > MaxHealth){
    //         health = MaxHealth;
    //         HealthBar.SetHealth(health);
    //     }
    // }

    public void TakeDamage(int damage){
        if(health >= 0){
            health-=damage;
            HealthBar.SetHealth(health);

        }
    }
}
