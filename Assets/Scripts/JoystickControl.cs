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
 

    public void Awake()
    {


        tilt = 2.0f;
      

      
    }
    public void FixedUpdate()
    {

        var tiltX = Input.GetAxis("Vertical") * tilt;
        var tiltY = Input.GetAxis("Horizontal") * tilt;
        
     

     
        
        dirX = Vector3.right * (dynamicJoystick.Horizontal * 4f);
        dirY = Vector3.up * (dynamicJoystick.Vertical * 4f);
        rb.AddForce(dirX * (speed * Time.fixedDeltaTime), ForceMode.VelocityChange);
        rb.AddForce(dirY * (speed * Time.fixedDeltaTime), ForceMode.VelocityChange);

    
        
    
    }



  
}
