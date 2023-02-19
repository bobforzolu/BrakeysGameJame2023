using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private EnemyWave[] enemyWave;
    public int currentWave { get; private set; }

    private Camera mainCamera;
    private float camHeight;
    private float camWidth;

    private float timer;
    private float SpawnTimer = 15f;
    private bool canSpawn;
    private GameObject player;
    private Transform playerpos;

    public int currentEnemy;
    public float spawnRadius = 2f;
    public static EnemySpawner enemySpawner;
    public bool SpawnEnd;
    private void Awake()
    {
        enemySpawner = this;
    }
    void Start()
    {
        mainCamera = Camera.main;
        camHeight = mainCamera.orthographicSize;
        camWidth = camHeight * mainCamera.aspect;

    }

    void Update()
    {
            currentEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (!SpawnEnd)
        {
            StartSpawnTimer();

        }
    }

    public void SpawnEnemy()
    { 

        for (int i = 0; i < enemyWave[currentWave].SpawnRatePerSecond; i++)
        {
            if(currentEnemy < 100) {
                GameObject enemy = ObjectPulling.instance.SpawnFromPool("Enemies", SpawnLocation(),Quaternion.identity);
                enemy.GetComponent<EnemyController>().SetEnemyData(enemyWave[currentWave].enemies[0]);
                enemyWave[currentWave].summonedEnemies++;
            
            }
            if (enemyWave[currentWave].summonedEnemies / enemyWave[currentWave].EnemyCount > 0.9f &&  currentWave< enemyWave.Length)
            { 
                currentWave++;
                if(currentWave >= enemyWave.Length)
                {
                    SpawnEnd = true;
                }
                

            }
           
            
        }

    }
    public Vector2 SpawnLocation()
    {
       
        Vector2 cameraPosition = mainCamera.transform.position;
        float cameraHeight = mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        // Calculate a random position around the camera view
        Vector2 spawnPosition = cameraPosition + new Vector2(Random.Range(-cameraWidth, cameraWidth), Random.Range(-cameraHeight, cameraHeight)).normalized * spawnRadius;

        return spawnPosition;

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