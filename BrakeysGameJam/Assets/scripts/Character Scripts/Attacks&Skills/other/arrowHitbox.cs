using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowHitbox : MonoBehaviour
{
    private IDamagable enemies;
    public int damage;
    public bool enemyisHit;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemies = collision.GetComponent<IDamagable>();
            if(enemies != null)
            {
            enemies.TakeDamage(damage);
                Destroy(gameObject);

            }
            enemyisHit = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
    }
    public void setDamade(int damage)
    {
        this.damage = damage;
    }



}
