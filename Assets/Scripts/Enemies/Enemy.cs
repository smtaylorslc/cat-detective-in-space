using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : LivingThing
{
    // We need to know what direction sprite is facing
    // to determine jump direction and to allow it to
    // flip around on collision.
    string direction;
    // Start is called before the first frame update
    void Start()
    {
        InitiateHealth();
        direction = "left";
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // The collider box is drawn so that the only triggers possible
        // are from the left or right, so any collision should trigger
        // a bounce off the wall.
        FlipEnemy(collider);
    }
    public void FlipEnemy(Collider2D collider){
        Rigidbody2D rb = transform.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(
            rb.velocity.x * -1,
            rb.velocity.y
        );
        transform.localScale = new Vector3(
            transform.localScale.x * -1,
            transform.localScale.y,
            transform.localScale.z
        );
        if(direction == "left"){
            direction = "right";
        } else {
            direction = "left";
        }
    }
    public void TakeDamage(Collider2D collider){
        if(collider.gameObject.GetComponent<HurtsEnemy>() != null){
            takeDamage(collider.gameObject.GetComponent<HurtsEnemy>().getDamage());
        }
    }
    public string GetDirection(){
        return(direction);
    }
}
