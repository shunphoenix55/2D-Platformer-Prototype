using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticFieldAttractor : MonoBehaviour
{
    public Transform corner1;
    public Transform corner2;

    public Vector2 gravityDirection;
    
    //public float minRotation;
    //public float maxRotation;

    public bool rotate = true;

    public Vector3 intendedRotation = new Vector3 (0, 0, 0);
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapAreaAll(corner1.position, corner2.position);
        if (colliders.Length > 0)
        {
            foreach (Collider2D collider in colliders)
            {   
                if (collider.GetComponent<Rigidbody2D>() != null)
                {
                    Rigidbody2D rb  = collider.GetComponent<Rigidbody2D>();
                    rb.AddForce(gravityDirection * Physics2D.gravity.magnitude * rb.mass);
                    if(rotate)
                    {
                    rb.transform.eulerAngles = intendedRotation;

                    }
                    /*if(rb.rotation < minRotation && rb.rotation > maxRotation)
                    {
                    }*/
                    
                }
            }
        }
    }
}
