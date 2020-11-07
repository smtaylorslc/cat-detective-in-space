using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    Rigidbody2D r2d;
    public GameObject explosionPrefab;
    int speed = 5;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        r2d.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col) {
        // Detect collision of bullet with enemy.
        if(col.tag == "MagmaBallTag") {
            GameObject go = Instantiate(explosionPrefab);
            go.transform.position = new Vector3(
                r2d.transform.position.x,
                r2d.transform.position.y,
                0f
            );
            Destroy(gameObject);
        }
    }
}
