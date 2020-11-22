using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingThing : MonoBehaviour
{
    public int maxHealth;
    // We need to set a default for this so we don't have to
    // tie an actual healthBar GO to enemies.
    public HealthBarScript healthBar = null;
    int currentHealth;
    public void InitiateHealth()
    {
        currentHealth = maxHealth;
        if(healthBar){
            healthBar.setMaxHealth(maxHealth);
        }
    }
    public void takeDamage(int damage){
        currentHealth -= damage;
        if(healthBar){
            healthBar.SetHealth(currentHealth);
        }
    }
    public int checkHealth(){
        return(currentHealth);
    }
}
