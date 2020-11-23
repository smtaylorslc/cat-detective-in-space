using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingThing : MonoBehaviour
{
    // Ground check vars. 
    [SerializeField] private LayerMask WhatIsGround;
    
    public float GroundedRadius = .2f;

    // Health vars.
    public int maxHealth;
    // We need to set a default for this so we don't have to
    // tie an actual healthBar GO to enemies.
    public HealthBarScript healthBar = null;
    float currentHealth;
    public void InitiateHealth()
    {
        currentHealth = maxHealth;
        if(healthBar){
            healthBar.setMaxHealth(maxHealth);
        }
    }
    public void takeDamage(float damage){
        currentHealth -= damage;
        if(healthBar){
            healthBar.SetHealth(currentHealth);
        }
    }
    public float checkHealth(){
        return(currentHealth);
    }
    public bool checkGrounded(){
        bool isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(
            new Vector2 (
                transform.position.x, 
                transform.position.y - gameObject.GetComponent<SpriteRenderer>().bounds.extents.y
            ),
            GroundedRadius,
            WhatIsGround
        );
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
            }
        }
        return(isGrounded);
    }
}
