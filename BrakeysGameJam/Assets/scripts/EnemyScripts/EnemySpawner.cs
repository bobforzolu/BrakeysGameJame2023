using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private EnemyWave[] enemyWave;
    private int currentWave;
    [SerializeField] private GameObject enemyPrefab;

    private Camera mainCamera;
    private float camHeight;
    private float camWidth;
    private float buffer = 1f;

    void Start()
    {
        mainCamera = Camera.main;
        camHeight = mainCamera.orthographicSize;
        camWidth = camHeight * mainCamera.aspect;

        SpawnEnemy();
    }

    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        for (int i = 0; i < enemyWave[currentWave].SpawnRatePerSecond; i++)
        {
            GameObject enemy = enemyPrefab;
            Instantiate(enemy, new Vector2(SpawnLocation().x,SpawnLocation().y ),Quaternion.identity);
            enemy.GetComponent<EnemyController>().SetEnemyData(enemyWave[currentWave].enemies[0]);

        }
    }
    public Vector2 SpawnLocation()
    {
        float randX = Random.Range(0, 2) == 0 ? -1 : 1;
        float randY = Random.Range(0, 2) == 0 ? -1 : 1;
        Vector2 randomLocation = new Vector2(Random.Range(camWidth + buffer, 2 * camWidth + buffer) * randX,
                                             Random.Range(camHeight + buffer, 2 * camHeight + buffer) * randY);
        return randomLocation;

    }

}

[System.Serializable]
public class EnemyWave{

    public int SpawnRatePerSecond;
    public int EnemyCount;
    public EnemyData[] enemies;

}