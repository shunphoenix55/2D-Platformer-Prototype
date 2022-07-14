using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularTester : MonoBehaviour
{
    public Transform targetTransform;
    public float angVelocity = 10f;
    public float timePeriod = 1f;

    private Rigidbody2D rb;
    private Vector2 radius;
    private Vector2 maxPos;

        void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        maxPos = rb.position;
        radius = targetTransform.position - rb.transform.position;
        timePeriod = Mathf.Sqrt(radius.magnitude/Physics2D.gravity.magnitude);
       

    }

    void FixedUpdate()
    {
        radius = targetTransform.position - rb.transform.position;
        rb.velocity = rb.angularVelocity * maxPos * Mathf.Cos(rb.angularVelocity * timePeriod) * Vector2.Perpendicular(radius);
        //rb.angularVelocity = angVelocity;
    }

    
}
