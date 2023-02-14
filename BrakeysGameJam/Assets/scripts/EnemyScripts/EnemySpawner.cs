using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private EnemyWave[] enemyWave;
    [SerializeField] private GameObject Enemy;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

[System.Serializable]
public class EnemyWave{

    public EnemyData[] enemies;

}