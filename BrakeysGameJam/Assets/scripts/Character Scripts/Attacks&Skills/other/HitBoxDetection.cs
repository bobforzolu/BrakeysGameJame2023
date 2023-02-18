using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxDetection : MonoBehaviour
{
    private List<IDamagable> enemies = new List<IDamagable>();
    private int damage;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
             AddEnemies(collision);
           

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       // RemoveEnemies(collision);
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
    public void SetableDoDamage( int damage)
    {
                int hitenemy = 1;
        foreach (IDamagable enemy in enemies)
        {
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
                hitenemy++;
                
            }
        }
        enemies.Clear();
    }
    public void DoDamage()
    {
        int hitenemy = 1;
        foreach (IDamagable enemy in enemies)
        {
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                hitenemy++;

            }
        }
                enemies.Clear();
    }
    public void UpdateDamage(int newdamage)
    {
        Debug.Log(newdamage);
        damage = newdamage;
    }
    public int Damage()
    {
        return damage;
    }
    private void OnDrawGizmos()
    {
        
    }


}
