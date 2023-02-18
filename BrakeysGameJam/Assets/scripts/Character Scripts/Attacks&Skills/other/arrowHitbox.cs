using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowHitbox : MonoBehaviour
{
    private IDamagable enemies;
    private int damage;
    private Camera mainCamera; // Reference to the main camera
    private Vector2 screenBounds; // Screen bounds of the camera view
    private float objectWidth; // Width of the enemy object
    private float objectHeight; // Height of the enemy object
    private void Start()
    {
      

    }
    private void OnEnable()
    {
        Invoke("Disableobj", 5f);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemies = collision.GetComponent<IDamagable>();
            if(enemies != null )
            {
              enemies.TakeDamage(damage);
               gameObject.SetActive(false);

            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
    }
    private void Update()
    {
        
    }
    public void setDamade(int damage)
    {
        this.damage = damage;
    }
    public void Disableobj()
    {
        gameObject.SetActive(false);
    }
    bool IsInCameraView()
    {
        // Get the screen bounds of the camera view
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Calculate the object's screen position
        Vector3 screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        // Check if the object is within the camera view
        if (screenPos.x < -gameObject.GetComponentInChildren<SpriteRenderer>().bounds.extents.x || screenPos.x > screenBounds.x * 2 + gameObject.GetComponentInChildren<SpriteRenderer>().bounds.extents.x ||
            screenPos.y < -gameObject.GetComponentInChildren<SpriteRenderer>().bounds.extents.y || screenPos.y > screenBounds.y * 2 + gameObject.GetComponentInChildren<SpriteRenderer>().bounds.extents.y)
        {
            return false;
        }

        return true;
    }
}




