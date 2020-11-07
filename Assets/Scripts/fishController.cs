using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishController : enemyControl
{
    float sineFreq = 7.0f;
    float sineMag = 0.5f;
    float initialY;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        initialY = transform.position.y;
    }
    public override void setEnemyPosition(){
        //Get enemy current position
        Vector2 position = transform.position;

        // This enemy follows a sine wave pattern.
        position = new Vector2(
            position.x - speed * Time.deltaTime,
            initialY + (Mathf.Sin(Time.time * sineFreq) * sineMag)
        );
        // Update enemy position
        transform.position = position;

    }
}
