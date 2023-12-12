using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int totalBlocks;  //Serialised for debugging
    
    void Start()
    {
        totalBlocks = FindObjectsOfType<Block>().Length;
    }

    public void BlockDestroyed()
    {
        totalBlocks--;
        if (totalBlocks <= 0)
        {
            // All blocks have been destroyed
            // Load the next level or show win screen
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
