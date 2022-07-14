using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticFIeldAttractorTrigger : MonoBehaviour
{
    public Transform minPos;
    public Transform maxPos;
    public Vector2 gravityDirection;
    public bool rotate = true;

    public Vector3 intendedEnterRotation = new Vector3 (0, 0, 0);
    public Vector3 intendedExitRotation = new Vector3(0, 0, 0);


 

    private void Start() 
    {
        BoxCollider2D box = gameObject.GetComponent<BoxCollider2D>();
        box.size = maxPos.localPosition - minPos.localPosition;
        box.offset = (maxPos.localPosition  - minPos.localPosition)/2 + minPos.localPosition; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   if(rotate)
        {other.transform.eulerAngles = intendedEnterRotation;}
        other.transform.position -= (transform.right - transform.up) * 0.5f;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(rotate)
        {
        other.transform.eulerAngles = intendedExitRotation;
        }
        other.transform.position += (transform.right - transform.up) * 0.5f;
        
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        Rigidbody2D rb  = other.GetComponent<Rigidbody2D>();
        rb.AddForce(gravityDirection * Physics2D.gravity.magnitude * rb.mass);
    }

}
