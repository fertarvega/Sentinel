using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float Health = 100f;
    private float MaxHealth = 100f;

    // private void death(){
    //     Destroy(this);
    // }
    
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
