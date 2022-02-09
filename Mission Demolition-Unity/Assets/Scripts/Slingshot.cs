/*
 * Author: Alex Jenkins
 * Date created: 2/9/22
 * Date last udpated: 2/9/22 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject prefabProjectile;

    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    public Rigidbody projectileRB;
    public float velocityMultiplier = 8f;


    private void Awake()
    {
        Transform launchPointTrans = transform.Find("launchPoint");
        launchPoint = launchPointTrans.gameObject;

        launchPoint.SetActive(false); //disable launchPoint
        launchPos = launchPointTrans.position; //
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!aimingMode) //if not aiming exit update
            return;
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 mouseDelta = mousePos3D - launchPos;

        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        //move projectile to new position
        Vector3 projectilePos = launchPos + mouseDelta;
        projectile.transform.position = projectilePos;


        if (Input.GetMouseButtonUp(0))
        {
            aimingMode = false;
            projectileRB.isKinematic = false;
            projectileRB.velocity = -mouseDelta * velocityMultiplier;
            FollowCam.POI = projectile;
            projectile = null;//emptys reference to instance projectile
        }
    }

    private void OnMouseEnter()
    {
        print("Slingshot: OnMouseEnter");
        launchPoint.SetActive(true);
    }

    private void OnMouseExit()
    {
        launchPoint.SetActive(false);
        print("Slingshot: OnMouseExit");
    }

    private void OnMouseDown()
    {
        aimingMode = true;
        projectile = Instantiate(prefabProjectile) as GameObject;
        projectile.transform.position = launchPos;
        projectileRB = projectile.GetComponent<Rigidbody>();
        projectileRB.isKinematic = true;
    }
}
