/*
 * Author: Alex Jenkins
 * Date created: 2/14/22
 * 
 * Last edited by:
 * Date last udpated: 2/14/22 
 * 
 * Description: Generate a cloud
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    [Header("Set in Inspector")]
    public GameObject cloudSphere;
    public int numOfSpheremin = 6;
    public int numOfSpheremax = 10;
    public Vector2 sphereScaleRangeX = new Vector2(4, 8);
    public Vector2 sphereScaleRangeY = new Vector2(3, 4);
    public Vector2 sphereScaleRangeZ = new Vector2(2, 4);
    public Vector3 sphereOffsetScale = new Vector3(5, 2, 1);
    public float scaleYmin = 2f;
    private List<GameObject> spheres;


    // Start is called before the first frame update
    void Start()
    {
        spheres = new List<GameObject>();
        int num = Random.Range(numOfSpheremin, numOfSpheremax);

        for(int i=0; i<num; i++)
        {
            GameObject sp = Instantiate<GameObject>(cloudSphere);
            spheres.Add(sp);

            Transform spTrans = sp.transform;
            spTrans.SetParent(this.transform);

            //Randomly assign a position
            Vector3 offset = Random.insideUnitSphere;
            offset.x *= sphereOffsetScale.x;
            offset.y *= sphereOffsetScale.y;
            offset.z *= sphereOffsetScale.z;
            spTrans.localPosition = offset;

            //Randomly assign scale
            Vector3 scale = Vector3.one;
            scale.x = Random.Range(sphereScaleRangeX.x, sphereScaleRangeX.y);
            scale.y = Random.Range(sphereScaleRangeY.x, sphereScaleRangeY.y);
            scale.z = Random.Range(sphereScaleRangeZ.x, sphereScaleRangeZ.y);

            //adjust y scale by x distance from core
            scale.y *= 1 - (Mathf.Abs(offset.x) / sphereOffsetScale.x);
            scale.y = Mathf.Max(scale.y, scaleYmin);

            spTrans.localScale = scale;

        }
    }

    // Update is called once per frame
    void Update()
    {
        /*key pess spacebar input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Restart();
        }*/
    }

    void Restart()
    {
        foreach(GameObject sp in spheres)
        {
            Destroy(sp);
        }
        Start();
    }
}
