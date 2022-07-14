using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPoint;

    public Vector2 direction;

    public float waitTime;
    
    void Start()
    {
        StartCoroutine("PeriodicShoot");
    }

    

    IEnumerator PeriodicShoot()
    {
       while(true)
       {
        Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        yield return new WaitForSeconds(waitTime);

       }
    }
}
