using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] private float jumpVelocity = 5f;
    [Range(0, 10)] [SerializeField] private float speed = 5f;
     
    [SerializeField] private LayerMask WhatIsGround;  
    [SerializeField] private Transform GroundCheck;

    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxcollider2d;
    public bool isGrounded = false;
    const float GroundedRadius = .2f;

    float horizontalMove = 0f;

    public Rigidbody2D throwable;
    public float attackSpeed = 0.5f;
    public float projectileSpeed = 2.5f;

    private void Awake()
    {
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        boxcollider2d = gameObject.GetComponent<BoxCollider2D>();

    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouse_pos_2d = new Vector2(mouse_position.x, mouse_position.y);
            // Calling this a "grenade" even though I know it's probably
            // not going to be a grenade -- just makes more sense to my
            // brain than "toss".
            Rigidbody2D grenade = Instantiate(
                throwable,
                transform.position,
                transform.rotation
            ) as Rigidbody2D;

            float coolDown = Time.time + attackSpeed;
            grenade.GetComponent<Rigidbody2D>().velocity = 
                (mouse_pos_2d - new Vector2(transform.position.x, transform.position.y)) * projectileSpeed;
        }
    }

    private void FixedUpdate()
    {
        rigidbody2d.velocity = new Vector2(horizontalMove*speed,rigidbody2d.velocity.y);

       
        isGrounded = false;

        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
            }
        }
    }
    
}
