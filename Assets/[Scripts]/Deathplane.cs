using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathplane : MonoBehaviour
{
    Vector3 _spawnPoint = new Vector3(0, 5, 0);

  

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.CompareTag("Player"))
        {
            collision.transform.position = _spawnPoint;

          
        }
    }

    public void UpdateSpawnPoint(Vector3 spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }

    public void SpawnPlayerToCheckpoint()
    {
        FindObjectOfType<PlayerBehavior>().transform.position = _spawnPoint;
    }
}
