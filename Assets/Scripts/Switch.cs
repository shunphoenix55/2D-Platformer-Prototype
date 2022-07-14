using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject door;

    public bool temporary;

    private int colliders;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        door.SetActive(false);

        if(temporary)
        {
            colliders += 1;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(temporary)
        {
            colliders -= 1;
            if(colliders == 0)
            {
                door.SetActive(true);
            }

        }
    }
}
