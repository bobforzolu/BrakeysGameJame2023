using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpeed : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddSpeed(float speed)
    {
        rb2d= GetComponent<Rigidbody2D>();
        rb2d.AddForce(Vector3.one, ForceMode2D.Impulse);
    }
}
