/*
 * Author: Alex Jenkins
 * Date created: 2/14/22
 * 
 * Last edited by:
 * Date last udpated: 2/14/22 
 * 
 * Description: control space for clouds to spawn
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCrafter : MonoBehaviour
{

    [Header("Set in Inspector")]
    public int numOfClouds = 40;
    public GameObject cloudPrefab;
    public Vector3 cloudPositionMin = new Vector3(-50, -5, 10);
    public Vector3 cloudPositionMax = new Vector3(150, 100, 10);
    public float cloudScaleMin = 1f;
    public float cloudScaleMax = 3f;
    public float cloudSpeedMultiplier = .5f;

    private GameObject[] cloudInstances;

    private void Awake()
    {
        cloudInstances = new GameObject[numOfClouds];

        GameObject anchor = GameObject.Find("CloudAnchor");

        GameObject cloud;
        for(int i=0; i<numOfClouds;i++)
        {
            cloud = Instantiate<GameObject>(cloudPrefab);

            //position cloud
            Vector3 cPos = Vector3.zero;
            cPos.x = Random.Range(cloudPositionMin.x, cloudPositionMax.x);
            cPos.y = Random.Range(cloudPositionMin.y, cloudPositionMax.y);

            //scale clouds
            float scaleU = Random.value;
            float scaleVal = Mathf.Lerp(cloudScaleMin, cloudScaleMax,scaleU);
            cPos.y = Mathf.Lerp(cloudPositionMin.y, cPos.y, scaleU);




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
