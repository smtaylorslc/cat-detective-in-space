using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Enemy
{
    public float moveSpeed = 2f;

    int directionInt = -1;
    Rigidbody2D rigidbody2d;
    private void Awake()
    {
        InitiateHealth();
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate(){
        if(GetDirection()=="left"){
            directionInt = -1;
        } else {
            directionInt = 1;
        }
        rigidbody2d.velocity = new Vector2(
            moveSpeed * directionInt, 
            rigidbody2d.velocity.y
        );
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
