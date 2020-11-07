using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
    }
    public virtual void setEnemyPosition(){
        // This method should be overridden for 
        // different enemy movement types.

        // The default movement is a straight line from right to left.

        //Get enemy current position
        Vector2 position = transform.position;

        position = new Vector2(position.x - speed * Time.deltaTime, position.y);
        // Update enemy position
        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        setEnemyPosition();
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
        // If enemy exits left of screen, destroy.
        if(transform.position.y < min.x - 2)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col) {
        // Detect collision of the enemy with bullet or player ship.
        if((col.tag == "PlayerBulletTag")) {
            Destroy(gameObject); // Destroy the enemy.
        }
    }
}
