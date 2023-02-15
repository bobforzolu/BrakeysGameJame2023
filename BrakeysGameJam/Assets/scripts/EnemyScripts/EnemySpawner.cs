using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private EnemyWave[] enemyWave;
    private int currentWave;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Camera  maincamera;
    public bool can;
    void Start()
    {
        maincamera = Camera.main;
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
            enemy.GetComponent<EnemyController>().SetEnemyData(enemyWave[currentWave].enemies[0]);
            Instantiate(enemy, new Vector2(maincamera.transform.position.x + Random.Range(-SpawnLocation().x, SpawnLocation().x), maincamera.transform.position.y+ Random.Range(-SpawnLocation().y, SpawnLocation().y)),Quaternion.identity);

        }
    }
    public Vector2 SpawnLocation()
    {
        float height = 2f * maincamera.orthographicSize;
        float width = height * maincamera.aspect;
        Vector2 measuer = new(height, width);
        return measuer;
    }

}

[System.Serializable]
public class EnemyWave{

    public int SpawnRatePerSecond;
    public int EnemyCount;
    public EnemyData[] enemies;

}