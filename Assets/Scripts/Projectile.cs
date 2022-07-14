using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float damage = 10f;
    public string ignoreTag = "Untagged";
    public float projectileVelocity = 10f;

    public Vector2 direction = new Vector2(-1, 0);

    private Rigidbody2D rb ;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = -(projectileVelocity * transform.right);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Health health = other.gameObject.GetComponent<Health>();
        if (health != null && !other.gameObject.CompareTag(ignoreTag))
        {
            
            
                health.currentHealth -= damage;
                health.DamageCheck();
        }

        Destroy(gameObject);

    }

   
}
