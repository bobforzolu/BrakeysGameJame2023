using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
    [SerializeField]private Animator animator;
    [SerializeField]private SpriteRenderer enemysprite;
    private Enemy enemy;
    public EnemyData enemyData;
    private Transform currentPosition;

    public  GameObject player;
    public  Transform playerPosition;
    private DropExperince dropExperince;

    void Start()
    {
        /// find the player in the scene
        enemy = new Enemy(enemyData);
        player = GameObject.FindGameObjectWithTag("Player");
        dropExperince = GetComponent<DropExperince>();
        playerPosition = player.transform;



        // set starting position
        currentPosition = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        FindPlayer();
    }

    public void FindPlayer()
    {
        // find the players postion
        playerPosition = player.transform;
        transform.position = Vector2.MoveTowards(currentPosition.position, playerPosition.position, enemyData.speed * Time.deltaTime);

    }
    public void SetEnemyData(EnemyData enemyData)
    {
        this.enemyData = enemyData;
        enemysprite = gameObject.GetComponentInChildren<SpriteRenderer>();

        if (enemyData.EnemySprite!= null)
        {
        enemysprite.sprite = enemyData.EnemySprite;
            enemysprite.color = enemyData.Color;

        }

        animator.runtimeAnimatorController = enemyData.animationClip;

    }
    #region damage and health recovery
    public void Recover(int Amount)
    {
        
    }

    /// <summary>
    /// takes damage when player attacks
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        ///enemy takes damage if 
        enemy.HealthAfterDamage(damage);
        if(enemy.currentHealth < 0)
        {
            dropExperince.DropExp();
            EnemyDeath();
        }
    }
    public void EnemyDeath()
    {
        
        Destroy(gameObject);
    }

    #endregion
}
