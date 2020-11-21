using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//alright so I probalby should have made some kind of player handerly script to hold a lot of this stuff
//but it's to late now so if we make another game just remember things like this should be in a player handler script
public class Throwable : MonoBehaviour
{
    [SerializeField] private Transform explosionPF;

    private float explodeTime = 2.5f;

    private Collider collide;
    private void Awake()
    {
        collide = gameObject.GetComponent<Collider>();
    }
    // Destroy throwable when it leaves the screen.
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    
    private void ExplodeObject()
    {
        Destroy(gameObject);
        OnExplode(transform.position);
    }
    private void OnExplode(Vector3 position)
    {
        Instantiate(explosionPF, position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collide.gameObject.GetComponent<ExplodeOnContact>() != null)
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
