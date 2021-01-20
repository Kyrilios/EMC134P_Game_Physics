using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{
    public Vector3 vectorVelocity;
    public Vector3 netForce;
    public bool netForceActive;
    public List<Vector3> forceList = new List<Vector3>();
    void Start()
    {

    }

    void FixedUpdate()
    {
        AddForces();
        if (netForce == Vector3.zero)
        {
            transform.position += vectorVelocity * Time.deltaTime;
            netForceActive = false;
        }else{
          
            netForceActive = true;
        }
        //transform.position += vectorVelocity * Time.deltaTime;

       
    }

    void AddForces()
    {
        netForce = Vector3.zero;
        foreach (Vector3 fv in forceList)
        {
            netForce += fv;
        }
    }
}


