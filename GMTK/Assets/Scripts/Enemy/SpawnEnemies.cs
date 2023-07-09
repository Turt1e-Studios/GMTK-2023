using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private float spawnRateChange;
    [SerializeField] private GameObject boss;
    [SerializeField] private float bossSpawnTime;

    private float _minimumSpawnRate;
    private float _spawnRate;

    // Start is called before the first frame update
    private void Start()
    {
        // Change spawn rate depending on the difficulty (from main menu)
        float difficulty = PlayerPrefs.GetInt("Difficulty");
        if (!PlayerPrefs.HasKey("Difficulty"))
        {
            Debug.Log("doesn't have difficulty key");
            _spawnRate = 5f;
        }
        else
        {
            _spawnRate = difficulty switch
            {
                1 => 7f,
                2 => 5f,
                3 => 3f,
                _ => _spawnRate
            };
            _minimumSpawnRate = difficulty switch
            {
                1 => 5f,
                2 => 3f,
                3 => 1f,
                _ => _minimumSpawnRate
            };
        }
        Debug.Log(_spawnRate);
        
        Spawn();
        StartCoroutine(EnemySpawn());

        // Boss doesn't spawn for easy difficulty
        if (difficulty != 1)
        {
            InvokeRepeating(nameof(BossSpawn), bossSpawnTime, bossSpawnTime);
        }
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
            yield return new WaitForSeconds(_spawnRate);

            Debug.Log("Spawnrate: " + _spawnRate);
            Spawn();
            
            _spawnRate -= spawnRateChange;
            if (_spawnRate < _minimumSpawnRate)
            {
                _spawnRate = _minimumSpawnRate;
            }
        }
    }

    private void Spawn()
    {
        Vector3 newPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), 0);
        Instantiate(enemies[Random.Range(0, enemies.Count)], newPosition, transform.rotation);
    }
}
