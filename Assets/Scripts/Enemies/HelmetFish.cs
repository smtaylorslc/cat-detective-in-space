using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetFish : Enemy
{
    public float fish_speed = 2f;
    // We need to know what direction sprite is facing
    // to determine jump direction and to allow it to
    // flip around on collision.
    void Jump()
    /* 
    We use this to trigger jumps based on animation frame.
    */
    {
        float x_direction = -1f;
        if(GetDirection()=="right"){
            x_direction = 1f;
        }
        Vector2 direction_to_go = new Vector2(
            transform.position.x + x_direction,
            transform.position.y + 1
        );
        if(checkGrounded()){
            transform.GetComponent<Rigidbody2D>().velocity = (
                direction_to_go - new Vector2(
                    transform.position.x,
                    transform.position.y
                )
            ) * fish_speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // The collider box is drawn so that the only triggers possible
        // are from the left or right, so any collision should trigger
        // a bounce off the wall.
        FlipEnemy(collider);
        TakeDamage(collider);
    }
}
