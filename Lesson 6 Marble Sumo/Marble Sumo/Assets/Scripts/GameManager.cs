using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Configuration
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnRadius = 8f;
    [SerializeField] float spawnHeight = 1f;
    
    // State Variabled
    [SerializeField] int enemiesToSpawn = 1;
    [SerializeField] int enemiesAlive = 0;

    void Start()
    {
        SpawnEnemies();
    }

    void Update()
    {
        if (enemiesAlive <= 0)
        {
            enemiesToSpawn++;
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector2 circlePosition = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPosition = new Vector3(circlePosition.x, spawnHeight, circlePosition.y);

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemiesAlive++;
        }
    }

    public void EnemyDefeated()
    {
        enemiesAlive--;
    }
}
