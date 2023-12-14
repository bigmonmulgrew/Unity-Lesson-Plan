using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    string[] specialScenes = { "Splash", "Win", "GameOver" };
    float delayInSeconds = 5f;

    void Start()
    {
        if (IsSpecialScene())
        {
            StartCoroutine(LoadFirstLevel()); // Load scene with index 1 after a delay
        }
    }

    bool IsSpecialScene()
    {
        foreach (string specialScene in specialScenes)
        {
            if (specialScene == SceneManager.GetActiveScene().name)
            {
                return true;
            }
        }
        return false;
    }

    IEnumerator LoadFirstLevel()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(1);
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
