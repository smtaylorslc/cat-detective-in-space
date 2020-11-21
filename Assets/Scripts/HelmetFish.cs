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
    private void OnTriggerEnter2D(Collider2D collider)
    {
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
}
