using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private Vector2 leftLimit;
    [SerializeField] private Vector2 rightLimit;

    private void Start()
    {
        if (enemyPrefabs == null || enemyPrefabs.Count == 0)
        {
            return;
        }
        InvokeRepeating("SpawnEnemy", 2f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs == null || enemyPrefabs.Count == 0)
        {
            return;
        }

        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        GameObject enemy = GameManager.Instance.GetEnemy(enemyPrefab);

        if (enemy != null)
        {
            float randomX = Random.Range(leftLimit.x, rightLimit.x);
            enemy.transform.position = new Vector2(randomX, leftLimit.y);
            enemy.transform.rotation = Quaternion.identity;
        }
    }
}
