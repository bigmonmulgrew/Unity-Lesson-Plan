using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Configurations
    [SerializeField] float moveSpeed = 25f;
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float groundPoundForce = 3f;
    [SerializeField] GameObject platform;

    //Cached references
    Rigidbody rb;

    // State Variables
    bool isGrounded;
    bool pound;
    int jumpCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Update is called each frame
    void Update()
    {
        Jump();
    }

    //Fixed update is triggered each Physics update Usually 60fps
    void FixedUpdate()
    {   
        // We are using force to move rather than fixed movement
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 forceToAdd = new Vector3(x, 0f, z) * moveSpeed;
        rb.AddForce(forceToAdd);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded || jumpCount < 2)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
                jumpCount++;
                               
            }
            else if (!isGrounded && jumpCount > 0) // Ground Pound
            {
                float calculatedForce = groundPoundForce * (transform.position.y - platform.transform.position.y);
                rb.AddForce(Vector3.down * calculatedForce, ForceMode.Impulse);
                pound = true;
            }
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            
            isGrounded = true;
            jumpCount = 0;
            if (pound) Knockback();
        }
    }

    void Knockback()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemies)
        {
            Vector3 direction = enemy.transform.position - transform.position;

            Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();
            enemyRb.AddForce(direction.normalized * groundPoundForce, ForceMode.Impulse);

            

        }
    }
}
