using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;


    public float x;
    public float y; 
    public float z; 
    //public Vector3 offset; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*
    void LateUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPos; 
    }

*/
    public void LateUpdate()
    {

        var position = target.position;
        
        Vector3 smoothedPos = Vector3.Lerp(transform.position, position, smoothSpeed);
       
        
        var temp = position.normalized;
        temp.x = position.x - x;
        temp.y = position.y  +- y;
        temp.z = smoothedPos.z - z;
        // Assign value to Camera position
        transform.position = temp;
    }
}
