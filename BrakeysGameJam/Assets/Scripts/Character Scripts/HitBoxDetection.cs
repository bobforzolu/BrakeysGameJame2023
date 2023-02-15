using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxDetection : MonoBehaviour
{
    private List<IDamagable> enemies = new List<IDamagable>();

    public void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
        AddEnemies(collision);
            Debug.Log(enemies.Count);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        RemoveEnemies(collision);
    }


    public void AddEnemies(Collider2D collision)
    {
        IDamagable enemy = collision.gameObject.GetComponent<IDamagable>();
        if(enemy != null)
        {
            enemies.Add(enemy);
        }

    }
    public void RemoveEnemies(Collider2D collision)
    {
        IDamagable enemy = collision.gameObject.GetComponent<IDamagable>();
        if(enemy != null )
        {
            enemies.Remove(enemy);
        }
        
    }
    public void DODamage( int damage)
    {
        foreach (IDamagable enemy in enemies)
        {
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
                

            }
        }
    }



}
