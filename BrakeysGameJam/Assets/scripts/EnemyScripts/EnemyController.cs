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
    private bool isDead;

    void Start()
    {
        /// find the player in the scene
        enemy = new Enemy(enemyData);
        dropExperince = GetComponent<DropExperince>();
        player = GameObject.FindGameObjectWithTag("Player");

        playerPosition = player.transform;



        // set starting position
    }

  

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {

        FindPlayer();
        }
    }

    public void FindPlayer()
    {
        // find the players postion
        currentPosition = gameObject.transform;

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
            enemysprite.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.75f, 1f);

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
     void TakeDamage(int damage)
    {
    }

    void IDamagable.TakeDamage(int damage)
    {
        
        ///enemy takes damage if 
        enemy.TakeDamage(damage);
        GameObject popup = ObjectPulling.instance.SpawnFromPool("popup", transform.position, Quaternion.identity);
        popup.GetComponent<PopupVisual>().setDamage(damage);
       
         if(enemy.currentHealth < 0 && !isDead)
        {
            ObjectPulling.instance.SpawnFromPool("Exp", transform.position, Quaternion.identity);
            isDead = true;
            gameObject.SetActive(false);

        }
    }

    void IDamagable.Recover(int Amount)
    {
        throw new System.NotImplementedException();
    }




    #endregion
}
