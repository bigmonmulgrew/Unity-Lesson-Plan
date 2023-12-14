using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Configuration 

    [SerializeField] float moveSpeed = 5f;
    
    //Cached references
    Rigidbody rb;
    Player player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindAnyObjectByType<Player>();
    }

    void FixedUpdate()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            rb.AddForce(direction * moveSpeed);
        }
    }
}
