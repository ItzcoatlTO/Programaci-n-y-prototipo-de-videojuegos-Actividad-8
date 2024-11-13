using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int score = 0;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject zigzagEnemyPrefab;
    [SerializeField] private int initialPoolSize = 5;

    private List<GameObject> enemyPool;
    private List<GameObject> zigzagEnemyPool;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeEnemyPools();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeEnemyPools()
    {
        enemyPool = new List<GameObject>();
        zigzagEnemyPool = new List<GameObject>();

        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);

            GameObject zigzagEnemy = Instantiate(zigzagEnemyPrefab);
            zigzagEnemy.SetActive(false);
            zigzagEnemyPool.Add(zigzagEnemy);
        }
    }

    public GameObject GetEnemy(GameObject prefab)
    {
        List<GameObject> pool = (prefab == zigzagEnemyPrefab) ? zigzagEnemyPool : enemyPool;

        foreach (GameObject enemy in pool)
        {
            if (enemy != null && !enemy.activeSelf)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }

        GameObject newEnemy = Instantiate(prefab);
        newEnemy.SetActive(true);
        pool.Add(newEnemy);
        return newEnemy;
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (enemy != null)
        {
            enemy.SetActive(false); 
            enemy.transform.position = Vector3.zero;
        }
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Puntaje: " + score);
    }

    public void RestartGame()
    {
        Debug.Log("¡Reiniciando la escena!");
        score = 0;

        foreach (GameObject enemy in enemyPool)
        {
            if (enemy != null)
            {
                RemoveEnemy(enemy);
            }
        }

        foreach (GameObject zigzagEnemy in zigzagEnemyPool)
        {
            if (zigzagEnemy != null)
            {
                RemoveEnemy(zigzagEnemy);
            }
        }
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
