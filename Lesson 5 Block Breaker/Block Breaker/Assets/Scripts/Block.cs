using UnityEngine;

public class Block : MonoBehaviour
{
    // Add more properties as needed, like pointsValue, hitPoints, etc.

    LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collider is the ball
        if (collision.gameObject.GetComponent<Ball>())
        {
            Destroy(gameObject); // Destroy the block
            levelManager.BlockDestroyed();
        }
    }

}
