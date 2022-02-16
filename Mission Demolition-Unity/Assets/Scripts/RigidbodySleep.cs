/*
 * Author: Alex Jenkins
 * Date created: 2/16/22
 * 
 * Last edited by:
 * Date last udpated: 2/16/22 
 * 
 * Description: set slab and wall Rigidbody to sleep
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class RigidSleep : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) rb.Sleep();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
