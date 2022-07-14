using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePointCheck : MonoBehaviour
{
    public float grappleDistance = 5f;
    private Rigidbody2D rb;
    private DistanceJoint2D distJoint;
    //private PlayerController player;

    private Vector2 distanceAnchor;
    private LayerMask grappleMask;

    private LineRenderer line;

    private bool renderLine;

    private Vector3 grapplePosition;

    private bool gKeyPressed;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        distJoint = gameObject.GetComponent<DistanceJoint2D>();
       // player = gameObject.GetComponent<PlayerController>();
        grappleMask = LayerMask.GetMask("Grapple Points");
        line = gameObject.GetComponent<LineRenderer>();
    }


    private void Update()
    {
        gKeyPressed = Input.GetKeyDown(KeyCode.G);
        if(renderLine)
        {
            line.SetPosition(0, rb.position);
            line.SetPosition(1, grapplePosition);
        }
    }
    
    void FixedUpdate()
    {
        if(gKeyPressed)
        {
            if(distJoint.enabled == false)
            {
                
                Collider2D[] jointColliders = Physics2D.OverlapCircleAll(rb.position, grappleDistance, grappleMask);
                if(jointColliders.Length > 0)
                {
                    distJoint.enabled = true;
                    Collider2D nearestCollider = jointColliders[0];
                    float nearestDistance = (jointColliders[0].transform.position - rb.transform.position).magnitude;
                    
                    
                    foreach (Collider2D collider in jointColliders)
                    {
                        float distance = (collider.transform.position - rb.transform.position).magnitude;
                        if(distance < nearestDistance)
                        {
                            nearestDistance = distance;
                            nearestCollider = collider;
                        }
                    }

                    distJoint.connectedBody = nearestCollider.attachedRigidbody;
                    line.enabled = true;
                    renderLine = true;
                    grapplePosition = nearestCollider.transform.position;
                }

            }

            else 
            {
                distJoint.enabled = false;

                line.enabled = false;
                renderLine = false;
            }
            
        }
    }
}
