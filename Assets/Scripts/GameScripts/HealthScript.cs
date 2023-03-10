using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public float Health = 100f;
    private float MaxHealth = 100f;
    [SerializeField]
    private Slider HealthBar;

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
