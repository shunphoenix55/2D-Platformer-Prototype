using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Side Movement")]
   public float moveAcceleration = 10f;
   public float minSpeed = 3f;
   public float maxSpeed = 10f;
    [Range(0,1)]
   public float airSpeedMultiplier = 1f;

    [Header("Jump Movement")]

    public float jumpVelocity = 100f;

    [SerializeField]
    private float jumpHeight;

    public Transform bottomTransform;
   private Rigidbody2D rb;
   private LayerMask mask;
   private DistanceJoint2D distJoint2D;

   private bool jumpKeyPressed;

   private Animator animator;

   private void Start() {
       rb = gameObject.GetComponent<Rigidbody2D>();
       mask = LayerMask.GetMask("Default");
       distJoint2D = gameObject.GetComponent<DistanceJoint2D>();
       animator = gameObject.GetComponent<Animator>();
       //Vector2 bottomVector = new Vector2(bottomTransform.position.x, bottomTransform.position.y);
   }


    private void Update()
    {
        jumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
    }
   private void FixedUpdate()
    {
        bool grounded = IsGrounded();
       SideMovement(grounded);
       JumpMovement(grounded);
       //Debug.Log(IsGrounded());
       //Debug.Log(rb.velocity);
       
   }

   private void SideMovement(bool grounded)
   {
    float moveDirection = Input.GetAxis("Horizontal");
       Vector2 moveForce =  moveDirection * moveAcceleration * rb.transform.right;  // new Vector2(moveDirection * moveAcceleration, 0) * rb.transform.right;
       Vector2 minVelocity = (transform.right * moveDirection * minSpeed) + (transform.up * Vector2.Dot(transform.up, rb.velocity)); //new Vector2(moveDirection * minSpeed, rb.velocity.y) * (rb.transform.right + new Vector3(0, 1, 0));
       float currentSideVelocity =Vector2.Dot(transform.right, rb.velocity);

        if(currentSideVelocity * moveDirection < minSpeed && !distJoint2D.enabled )
        {
            rb.velocity = minVelocity;
            //Debug.Log(minSpeed);
            //Debug.Log(moveDirection);
            //Debug.Log(minSpeed * moveDirection);
        }
        if(currentSideVelocity * moveDirection < maxSpeed)
       {   if(grounded)
            {
              rb.AddForce(moveForce);
            }

            else
            {
                rb.AddForce(moveForce * airSpeedMultiplier);
            }
       }
      /* if (moveDirection == 0f && !IsGrounded())
       {
           rb.velocity = new Vector2 (0, rb.velocity.y);
       }
       */ //Debug.Log(rb.velocity);

       /*if (moveDirection != 0)
       {
           animator.SetBool("IsRunning", true);
       }

       else
       {
           animator.SetBool("IsRunning", false);
       }*/
   }

   private void JumpMovement(bool grounded)
   {
       if(jumpKeyPressed && grounded)
       {
           rb.velocity = Vector2.Dot(rb.velocity, transform.right) * transform.right + (jumpVelocity * transform.up);
       }
       jumpHeight = -(jumpVelocity * jumpVelocity) / (2 * Physics2D.gravity.y);
   }

   private bool IsGrounded()
   {
       RaycastHit2D[] hits = Physics2D.CircleCastAll(bottomTransform.position, 0.05f, new Vector2(0, 0));
       if (hits.Length == 0)
       {
           return false;
       }
       foreach (RaycastHit2D hit  in hits)
       {
       if (hit != false && hit.collider.gameObject != gameObject)
       {
           return true;
       }
       /*else
       {
           return false;
       }*/
       }
       return false;
   }

}
    
