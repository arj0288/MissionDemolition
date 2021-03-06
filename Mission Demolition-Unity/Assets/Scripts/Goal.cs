/*
 * Author: Alex Jenkins
 * Date created: 2/23/22
 * 
 * Last edited by:
 * Date last udpated: 2/23/22 
 * 
 * Description: Allow goal to be triggered when projectile hits it
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static public bool goalMet = false;

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Projectile")
        {
            
            Goal.goalMet = true;
            Color c = GetComponent<Renderer>().material.color;
            c.a = 1;
            GetComponent<Renderer>().material.color = c;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
