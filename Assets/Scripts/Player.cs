using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public GameObject laserPrefab; 
    public Transform laserSpawnPoint; 
    public int initialPoolSize = 10;
    private List<GameObject> laserPool;
    private void Start()
    {
        InitializeLaserPool();
    }
    private void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireLaser();
        }
    }
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 position = transform.position;
        position.x += horizontalInput * speed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, -7.5f, 7.5f); 
        transform.position = position;
    }
    void InitializeLaserPool()
    {
        laserPool = new List<GameObject>();

        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateNewLaser();
        }
    }

    void FireLaser()
    {
        GameObject laser = GetPooledLaser();
        if (laser != null)
        {
            laser.transform.position = laserSpawnPoint.position; 
            laser.transform.rotation = laserSpawnPoint.rotation;
            laser.SetActive(true); 
        }
    }

    GameObject GetPooledLaser()
    {
        foreach (var laser in laserPool)
        {
            if (!laser.activeSelf) 
            {
                return laser;
            }
        }

        return CreateNewLaser();
    }

    GameObject CreateNewLaser()
    {
        GameObject laser = Instantiate(laserPrefab);
        laser.SetActive(false); 
        laserPool.Add(laser);
        return laser;
    }
}

