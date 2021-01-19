using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{
    public Vector3 velocityVector;
    public Vector3 netForceVector;
    public List<Vector3> forceVectorList = new List<Vector3>();

    void Start()
    {
        
    }


    void FixedUpdate()
    {
        Addforces();
        if (netForceVector == Vector3.zero) {
            transform.position += velocityVector * Time.deltaTime;
        } else {
            Debug.LogError("Unbalanced Force Detected.");
        }
    }

    void Addforces() {
        netForceVector =Vector3.zero;

        foreach (Vector3 forceVector in forceVectorList){
            netForceVector += forceVector;
        }    
    }
}
