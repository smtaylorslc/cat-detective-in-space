using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//alright so I probalby should have made some kind of player handerly script to hold a lot of this stuff
//but it's to late now so if we make another game just remember things like this should be in a player handler script
public class Throwable : MonoBehaviour
{
    [SerializeField] private Transform explosionPF;

    private float explodeTime = 2.5f;

    // Destroy throwable when it leaves the screen.
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    
    private void ExplodeObject()
    {
        Destroy(gameObject);
        Instantiate(
            explosionPF, 
            transform.position, 
            Quaternion.identity
        );
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // This is really fucky.
        // I feel like there ought to be better ways
        // to make custom gameObject params
        // available to other scripts.
        if (collider.gameObject.GetComponent<ExplodeOnContact>() != null)
        {
            ExplodeObject();
        }
    }
    private void Update()
    {
        explodeTime -= Time.deltaTime;
        if (explodeTime <= 0f)
        {
            ExplodeObject();
        }
    }

}
