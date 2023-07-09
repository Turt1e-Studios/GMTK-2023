using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private float initialSpawnRate;
    [SerializeField] private float spawnRateChange;
    [SerializeField] private GameObject boss;
    [SerializeField] private float bossSpawnTime;

    private const float MinimumSpawnRate = 1.0f;
    private float spawnRate;

    // Start is called before the first frame update
    private void Start()
    {
        spawnRate = initialSpawnRate;
        Spawn();
        StartCoroutine(EnemySpawn());
        InvokeRepeating(nameof(BossSpawn), bossSpawnTime, bossSpawnTime);
    }

    private void BossSpawn()
    {
        Vector3 newPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), 0);
        Instantiate(boss, newPosition, transform.rotation);
    }

    private IEnumerator EnemySpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);

            Spawn();
            
            spawnRate -= spawnRateChange;
            if (spawnRate < MinimumSpawnRate)
            {
                spawnRate = MinimumSpawnRate;
            }
        }
    }

    private void Spawn()
    {
        Vector3 newPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), 0);
        Instantiate(enemies[Random.Range(0, enemies.Count)], newPosition, transform.rotation);
    }
}
