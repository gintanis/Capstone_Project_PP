using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;


public class JoystickControl : MonoBehaviour
{
    public float speed;
    public DynamicJoystick dynamicJoystick;
    public Rigidbody rb;

    Vector3 m_EulerAngleVelocity;

    private Vector3 dirY;
    private Vector3 dirX; 

    public float dir;


    public float tilt;
 

    public float minClamp = -90.0f;
    public float maxClamp = 90f;
    public float sensitivity = 1f;

    Quaternion _initialRotation;
    float _pitch, _yaw;
    
    public void Awake()
    {


        tilt = 2.0f;
        _initialRotation = transform.rotation;
      

      
    }
    public void FixedUpdate()
    {

    
     

     
        
        dirX = Vector3.right * (dynamicJoystick.Horizontal * 4f);
        dirY = Vector3.up * (dynamicJoystick.Vertical * 4f);
        rb.AddForce(dirX * (speed * Time.fixedDeltaTime), ForceMode.VelocityChange);
        rb.AddForce(dirY * (speed * Time.fixedDeltaTime), ForceMode.VelocityChange);



 
        _pitch = Mathf.Clamp(_pitch + dynamicJoystick.Vertical * sensitivity, minClamp, maxClamp);

        _yaw = Mathf.Clamp(_yaw - dynamicJoystick.Horizontal * sensitivity, minClamp, maxClamp);

        transform.rotation = _initialRotation * Quaternion.Euler(-_pitch, -_yaw, 0);
    
    }



  
}
