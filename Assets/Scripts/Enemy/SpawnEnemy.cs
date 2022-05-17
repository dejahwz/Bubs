using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;

    private GameObject newEnemy;
    private int randomSpawnZone;
    private float randomXposition, randomYposition;
    private Vector2 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnNewEnemy", 0f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnNewEnemy()
    {
        randomSpawnZone = Random.Range(0, 4);
        
        switch (randomSpawnZone)
        {
            case 0:
                randomXposition = Random.Range(5f, 9f);
                randomYposition = Random.Range(-4, -4);
                break;
            case 1:
                randomXposition = Random.Range(9f, 9f);
                randomYposition = Random.Range(-0.3f, -0.3f);
                break;
            case 2:
                randomXposition = Random.Range(-9f, -9f);
                randomYposition = Random.Range(-2.7f, -2.7f);
                break;
            case 3:
                randomXposition = Random.Range(-9f, -4.2f);
                randomYposition = Random.Range(-6.6f, -6.6f);
                break;
        }
        spawnPosition = new Vector2(randomXposition, randomYposition);
        newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
    }
}
