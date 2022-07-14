using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagneticAttractor : MonoBehaviour
{
   //public Transform targetTransform;
   [Header("Attraction")]
   public float attractForceMagnitude = 1f;

   public float attractMagneticFieldRadius = 30f;
   [Header("Repulsion")]
   public float repelForceMagnitude = 100f;
   public float repelFieldRadius = 10f;

    private Vector2 difference;
    private Vector2 forceDirection;
    private Rigidbody2D rb;

    private Collider2D[] magneticColliders;

    private bool kKeyPressed;
    private bool lKeyPressed;

    private void Start() 
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        kKeyPressed = Input.GetKey(KeyCode.K);
        lKeyPressed = Input.GetKey(KeyCode.L);
    }
    private void FixedUpdate() 
    {   if(kKeyPressed)
        {
            magneticColliders =  Physics2D.OverlapCircleAll(rb.position, attractMagneticFieldRadius);
            foreach (Collider2D collider in magneticColliders)
            {   Rigidbody2D magneticRb = collider.GetComponent<Rigidbody2D>();
                if(collider.CompareTag("Magnetic") && magneticRb != null)
                {
                difference = rb.transform.position - magneticRb.transform.position;
                forceDirection = difference / difference.magnitude;
                Vector2 magneticForce =forceDirection * attractForceMagnitude * magneticRb.mass/ (difference.magnitude * difference.magnitude);
                magneticRb.AddForce(magneticForce);

                }
            }
        }

        else if(lKeyPressed)
        {
            magneticColliders =  Physics2D.OverlapCircleAll(rb.position, repelFieldRadius);
            foreach (Collider2D collider in magneticColliders)
            {   Rigidbody2D magneticRb = collider.GetComponent<Rigidbody2D>();
                if(collider.CompareTag("Magnetic") && magneticRb != null)
                {
                difference = magneticRb.transform.position - rb.transform.position ;
                forceDirection = difference / difference.magnitude;
                Vector2 magneticForce =forceDirection * repelForceMagnitude * magneticRb.mass/ (difference.magnitude * difference.magnitude);
                magneticRb.AddForce(magneticForce);

                }
            }
            
            
            //rb.AddForce(magneticForce);
        }
    }
}
