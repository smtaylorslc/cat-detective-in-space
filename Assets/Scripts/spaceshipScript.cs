using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipScript : MonoBehaviour
{
    Rigidbody2D r2d;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Bottom left point of screen
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

        // top right point of screen
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

        // Move the spaceship when an arrow key is pressed
        
        if (Input.GetKey("up")) {
            if (r2d.transform.position.y < max.y) 
                r2d.velocity = new Vector2(0, 10);
            else
                r2d.velocity = new Vector2(0, 0);
        }
            
        else if (Input.GetKey("down")) {
            if (r2d.transform.position.y > min.y) 
                r2d.velocity = new Vector2(0, -10);
            else
                r2d.velocity = new Vector2(0, 0);
        }
        else
            r2d.velocity = new Vector2(0, 0);
        

        
        if (Input.GetKeyDown("space")) {
            GameObject go = Instantiate(bulletPrefab);
            go.transform.position = new Vector3(
                r2d.transform.position.x,
                r2d.transform.position.y,
                0f
            );
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // Detect collision of player ship with magma ball
        if((col.tag == "MagmaBallTag")) {
            Destroy(gameObject); // Destroy the player's ship.
        }
    }
}
