﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(transform.up + new Vector3(1, 0, 0));
    }
}
