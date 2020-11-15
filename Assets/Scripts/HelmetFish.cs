using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetFish : MonoBehaviour
{
    public float projectileSpeed = 2f;
    // We need to know what direction sprite is facing
    // to determine jump direction and to allow it to
    // flip around on collision.
    string direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = "left";
    }

    // Update is called once per frame
    void Update()
    {
        float current_velocity = transform.GetComponent<Rigidbody2D>().velocity.x ;
        if(current_velocity <= 0){
            direction = "left";
        } else if (current_velocity == 0){
        } else {
            direction = "right";
        }
    }
    void Jump()
    /* 
    We use this to trigger jumps based on animation frame.
    */
    {
        float x_direction = -1f;
        if(direction=="right"){
            x_direction = 1f;
        }
        Vector2 direction_to_go = new Vector2(
            transform.position.x + x_direction,
            transform.position.y + 1
        );
        transform.GetComponent<Rigidbody2D>().velocity = (
            direction_to_go - new Vector2(
                transform.position.x,
                transform.position.y
            )
        ) * projectileSpeed;
    }
}
