using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsTester : MonoBehaviour
{
    public Transform minPos;
    public Transform maxPos;

    private BoxCollider2D box;

    private void Start() 
    {
        box = gameObject.GetComponent<BoxCollider2D>();
        
        

    }

    private void FixedUpdate() {
        box.size = maxPos.localPosition - minPos.localPosition;
        box.offset = (maxPos.localPosition  - minPos.localPosition)/2 + minPos.localPosition; //(maxPos.localPosition - minPos.localPosition - new Vector3(1f, 1f, 0))/2;
    }
}
