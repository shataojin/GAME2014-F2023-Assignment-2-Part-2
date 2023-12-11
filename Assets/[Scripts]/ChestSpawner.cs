using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    public GameObject chestPrefab; // The prefab of the chest you want to spawn
    public Transform[] spawnPoints; // Array of empty GameObjects serving as spawn points
    public int numberOfChestsToSpawn = 3; // Adjust the number of chests to spawn as needed

    void Start()
    {
        SpawnChests();
    }

    void SpawnChests()
    {
        // Shuffle the spawnPoints array to randomize the selection
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Transform temp = spawnPoints[i];
            int randomIndex = Random.Range(i, spawnPoints.Length);
            spawnPoints[i] = spawnPoints[randomIndex];
            spawnPoints[randomIndex] = temp;
        }

        // Activate the random number of spawn points and spawn chests
        for (int i = 0; i < Mathf.Min(numberOfChestsToSpawn, spawnPoints.Length); i++)
        {
            Transform spawnPoint = spawnPoints[i];
            if (spawnPoint != null)
            {
                spawnPoint.gameObject.SetActive(true); // Activate the spawn point
                Instantiate(chestPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}
