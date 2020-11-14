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
    public float coolDown;
    public float projectileSpeed = 400;
    public float aimAngle;

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
            Rigidbody2D toss = Instantiate(throwable, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;

            //toss.GetComponent<Rigidbody2D>().AddForce(transform.position * aimAngle * 10f);
            //this is the big problem, I've manage to get code for an aim angle...I just don't know how to use it properly, the above line doesn't work
            //try it out to see the problem, if you find a solution please tell me

            coolDown = Time.time + attackSpeed;
            Vector3 m_pos = Input.mousePosition;
            Vector3 g_pos = Camera.main.WorldToScreenPoint(throwable.transform.position);
            m_pos.x = m_pos.x - g_pos.x;
            m_pos.y = m_pos.y - g_pos.y;
            aimAngle = (Mathf.Atan2(m_pos.y, m_pos.x) * Mathf.Rad2Deg);

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
