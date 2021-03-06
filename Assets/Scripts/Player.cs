﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LivingThing
/*
Inheriting from LivingThing gives us the InitiateHealth
and takeDamage methods.
*/
{
    // Grounded var.
    public bool isGrounded = false;
    
    // Jump vars.
    [Range(0, 10)] [SerializeField] private float jumpVelocity = 10f;
    [Range(0, 10)] [SerializeField] private float speed = 5f;
    bool currently_jumping = false;
    
    // General GO access vars.
    private SpriteRenderer Sprite;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxcollider2d;
    Animator animator;

    // Movement vars.
    float horizontalMove = 0f;

    // Attack vars.
    public Rigidbody2D throwable;
    public float projectileSpeed = 5f;

    private void Awake()
    {
        InitiateHealth();
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        boxcollider2d = gameObject.GetComponent<BoxCollider2D>();
        Sprite = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetBool("Grounded", isGrounded);
        animator.SetBool("Falling", rigidbody2d.velocity.y < 0);
        if(currently_jumping && isGrounded){
            currently_jumping = false;
            animator.SetBool("Jumping", false);
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            animator.SetBool("Jumping", true);
            currently_jumping = true;
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

            grenade.GetComponent<Rigidbody2D>().velocity = (mouse_pos_2d - new Vector2(transform.position.x, transform.position.y)) * projectileSpeed;
        }
        animator.SetBool("Walking", (horizontalMove != 0));
        if (horizontalMove > 0 && Sprite.flipX)
        {
            Sprite.flipX = false;
        }
        
        else if (horizontalMove < 0 && !Sprite.flipX)
        {
            // ... flip the player.
            Sprite.flipX = true;

        }
    }

    private void FixedUpdate()
    {
        rigidbody2d.velocity = new Vector2(horizontalMove*speed,rigidbody2d.velocity.y);
        isGrounded = checkGrounded();
    }
    
}
