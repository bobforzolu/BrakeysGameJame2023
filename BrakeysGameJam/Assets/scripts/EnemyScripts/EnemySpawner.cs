using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private EnemyWave[] enemyWave;
    private int currentWave;

    private Camera mainCamera;
    private float camHeight;
    private float camWidth;
    public float buffer = 5f;

    private float timer;
    private float SpawnTimer = 15f;
    private bool canSpawn;

    public int currentEnemy;

    void Start()
    {
        mainCamera = Camera.main;
        camHeight = mainCamera.orthographicSize;
        camWidth = camHeight * mainCamera.aspect;

    }

    void Update()
    {
        StartSpawnTimer();
    }

    public void SpawnEnemy()
    { 

        for (int i = 0; i < enemyWave[currentWave].SpawnRatePerSecond; i++)
        {
            currentEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if(currentEnemy < 100) {
                GameObject enemy = ObjectPulling.instance.SpawnFromPool("Enemies", SpawnLocation(),Quaternion.identity);
                enemy.GetComponent<EnemyController>().SetEnemyData(enemyWave[currentWave].enemies[0]);
                enemyWave[currentWave].summonedEnemies++;
            
            }
            if (enemyWave[currentWave].summonedEnemies / enemyWave[currentWave].EnemyCount > 0.7f &&  currentWave< enemyWave.Length)
            { 
                currentWave++;

            }
            else
            {

            }
            
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

    public void StartSpawnTimer()
    {
        if(canSpawn)      
        {
            canSpawn= false;
            timer = SpawnTimer;
            SpawnEnemy();

        }
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                canSpawn= true;
            }
        }

    }

}

[System.Serializable]
public class EnemyWave{

    public int SpawnRatePerSecond;
    public int EnemyCount;
    public int summonedEnemies;
    public EnemyData[] enemies;
    

}