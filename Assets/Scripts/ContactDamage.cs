using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    // Start is called before the first frame update

    public float damage = 10f;
    public bool needsVelocity;

    public string ignoreTag = "Untagged";

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Health health = other.gameObject.GetComponent<Health>();
        if (health != null && !other.gameObject.CompareTag(ignoreTag))
        {
            if(!needsVelocity)
            {
                health.currentHealth -= damage;
                health.DamageCheck();
            }

            else
            {
                Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
                if(rb!=null)
                {
                    if(rb.velocity != new Vector2(0,0))
                    {
                        health.currentHealth -= damage;
                        health.DamageCheck();
                    }
                }

            }
        }
    }


}
    
