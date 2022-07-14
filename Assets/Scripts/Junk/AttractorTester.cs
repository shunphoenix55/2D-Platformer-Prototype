using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractorTester : MonoBehaviour
{
 public Transform targetTransform;

 private Vector2 difference;
 private Rigidbody2D rb;

private void Start() 
{
    rb = gameObject.GetComponent<Rigidbody2D>();
}
 private void FixedUpdate() 
 {
     difference = targetTransform.position - rb.transform.position;
     rb.velocity = difference;
 }
}
