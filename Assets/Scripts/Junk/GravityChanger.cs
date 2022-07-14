using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    public bool up = false;
    public bool down = true;
    public bool right = false;

    public bool left = false;

    private Rigidbody2D rb ;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(up)
        {
            rb.AddForce(new Vector2(0, Physics2D.gravity.magnitude * 2 * rb.mass));
        }

        if(down)
        {
            rb.AddForce(new Vector2(0, Physics2D.gravity.y));
        }

       
        if(right)
        {
           // rb.gravityScale = 0;
            rb.AddForce(new Vector2(Physics2D.gravity.magnitude, Physics2D.gravity.magnitude) * rb.mass);
        }

        if(left)
        {
           // rb.gravityScale = 0;
            rb.AddForce(new Vector2(-Physics2D.gravity.magnitude, Physics2D.gravity.magnitude) * rb.mass);

        }
    }
}
