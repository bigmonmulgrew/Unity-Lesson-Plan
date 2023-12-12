using UnityEngine;
using UnityEngine.SceneManagement;

public class Shredder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Destroy(collision.gameObject);  // Destroy the ball
        SceneManager.LoadScene("GameOver"); // Load the Game Over scene
        
    }
}
