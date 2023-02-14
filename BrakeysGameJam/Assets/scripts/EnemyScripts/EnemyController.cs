using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
    private Transform currentPosition;
    private static Transform playerPosition;
    private GameObject player;

    public EnemyData enemyData;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       currentPosition = gameObject.transform ;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform;
        FindPlayer();
    }

    public void FindPlayer()
    {
        transform.position = Vector2.MoveTowards(currentPosition.position, playerPosition.position, enemyData.speed * Time.deltaTime);

    }
    public void SetEnemyData(EnemyData enemyData)
    {
        this.enemyData = enemyData;
    }
    #region damage and health recovery
    public void Recover(int Amount)
    {
        
    }

    public void TakeDamage(int damage)
    {
    }
    #endregion
}
