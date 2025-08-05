using UnityEngine;
public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Assign your pipe/pillar prefab here
    public float spawnInterval = 2f;  // Time in seconds between spawns
    public float horizontalSpawnX = 10f; // X position to spawn at (off-screen to the right)
    public float minY = -2f;          // Minimum Y position for spawning
    public float maxY = 2f;           // Maximum Y position for spawning
    public bool isPlayerAlive = true; // This should be set to false when the player dies
    private float timer = 0f;
    void Update()
    {
        // If player is alive, run the spawn logic
        if (isPlayerAlive)
        {
            timer += Time.deltaTime;
            // If enough time has passed, spawn a new obstacle
            if (timer >= spawnInterval)
            {
                SpawnObstacle();
                timer = 0f; // Reset the timer
            }
        }
    }
    void SpawnObstacle()
    {
        // Choose a random Y position between min and max
        float randomY = Random.Range(minY, maxY);
        // Create a new spawn position using the fixed X and random Y
        Vector3 spawnPos = new Vector3(horizontalSpawnX, randomY, 0f);
        // Instantiate (clone) the prefab at the position with default rotation
        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
    // OPTIONAL: Call this from another script when player dies
    public void StopSpawning()
    {
        isPlayerAlive = false;
    }
}