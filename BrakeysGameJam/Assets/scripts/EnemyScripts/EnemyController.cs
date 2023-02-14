using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
    private Transform currentPosition;
    private static Transform playerPosition;
    [SerializeField]private GameObject player;
    [SerializeField]private Animator animator;
    [SerializeField] private SpriteRenderer enemysprite;

    [SerializeField] private EnemyData enemyData;
    void Start()
    {
        /// find the player in the scene
        player = GameObject.FindGameObjectWithTag("Player");

        // set starting position
       currentPosition = gameObject.transform ;
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
        enemysprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        this.enemyData = enemyData;
        if(enemyData.EnemySprite!= null)
        {
        enemysprite.sprite = enemyData.EnemySprite;

        }

        animator.runtimeAnimatorController = enemyData.animationClip;

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
