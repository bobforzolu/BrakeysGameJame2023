using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBombHitLogic : MonoBehaviour
{
    private Animator animator;

    private IDamagable enemies;
    private int damage;
    private bool hit;
    private bool explosionhit;
    private Rigidbody2D rb2d;
    AudioSource audioSource;

    private void Start()
    {
        animator= GetComponent<Animator>();
        rb2d = GetComponentInParent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemies = collision.GetComponent<IDamagable>();
            if (enemies != null)
            {
                audioSource.Play();
                hit= true;
                animator.SetBool("hit", true);

                enemies.TakeDamage(damage);
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
    }
    private void Update()
    {
        if (hit)
        {
            rb2d.velocity = Vector2.zero;
            hit= false;
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    public void setDamade(int damage)
    {
        this.damage = damage;
    }
}
