/*
 * Author: Alex Jenkins
 * Date created: 2/9/22
 * 
 * Last edited by:
 * Date last udpated: 2/9/22 
 * 
 * Description: Control Camera to follow projectile
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

    static public GameObject POI; //static point of interest
    public float camZ;//desired z pos of camera

    [Header("Set in Inspector")]
    public float easing = .05f;
    public Vector2 minXY = Vector2.zero;

    private void Awake()
    {
        camZ = this.transform.position.z;
    }

    private void FixedUpdate()
    {
        //if (POI == null) //if no POI do not update
        //return;

        //Vector3 destination = POI.transform.position;

        Vector3 destination;
        if(POI==null)
        {
            destination = Vector3.zero;
        }
        else
        {
            destination = POI.transform.position;
            if(POI.tag=="Projectile")
            {
                if(POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    POI = null;
                }
            }
        }


        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);

        destination = Vector3.Lerp(transform.position, destination, easing); //interpolate from current cam pos towards destination
        destination.z = camZ;
        transform.position = destination;

        Camera.main.orthographicSize = destination.y + 10;
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
