using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public MicController micControl;
    public float micLoud;

  
    
    [Header("Player Data")]
    public GameObject playerRB; 
    public Rigidbody rb;
    public float y;
    public float SpeedZ = 0.25f;
    public float SpeedY = 0.0f;
    public int lives = 3;
    public List<Image> livesImage;


    [Header("Lives")] public GameObject L1, L2, L3; 


    [Header("UI Stuff")] public GameObject b;
    public Text instructPlayer;
    public GameObject h;
    public Text heightVel;
    public MicController mC;
   
 
    [Header("BREATH")] 
    //add to list later
    public float inB;
    public float holdB;
    public float outB;
    public List<float> _timers = new List<float>();
    public bool IsBreathingOut;
    private float micInput;
    public BreathControl bC;

    public GameObject bControl;  
    // Start is called before the first frame update

    [Header("Points")] public float points;
    public GameObject sBoard;
    public Text sText;
    public float counter;
    
    
    
    
    public void Awake()
    {
        L1.gameObject.SetActive(true);
        L2.gameObject.SetActive(true);
        L3.gameObject.SetActive(true);


        
       
        inB = 4f;
        holdB = 7f;
        outB = 8f; 
            
        _timers.Add(inB );
        _timers.Add(holdB);
        _timers.Add(outB);

        
        
        /*
         * increment = .5f;
         * maxSpeed = 5f;
         *
         * maxHeight = 30f; 
         */

        
        
        
        instructPlayer = b.GetComponent<Text>(); 

        heightVel = h.GetComponent<Text>();
        sText = sBoard.GetComponent<Text>(); 
    }

    public void Start()
    {
        mC = micControl.GetComponent<MicController>(); 
        rb = playerRB.GetComponent<Rigidbody>();
        bC = bControl.GetComponent<BreathControl>(); 


    }

    public void Update()
    {

   
    }

    public void FixedUpdate()
    {
        sText.text = "Score: " + Mathf.Round(points); 
        y = rb.velocity.y; 

        micLoud = mC.MicLoudness;


        var position = rb.transform.position;
        heightVel.text = "Height: " + Mathf.Round(position.y) + " " + "Distance: " + Mathf.Round(position.z);


        rb.AddForce(transform.forward * SpeedZ);
  
        //change later
        if (micLoud >= .025f)
        {
            rb.AddForce(transform.up * SpeedY);
            IsBreathingOut = true;

            if (IsBreathingOut && bC.outB < 8)
            {
                points += Time.deltaTime * 10;
            }

        }
        else
        {
            IsBreathingOut = false; 
        }
        
        
    

        Vector3 down = transform.TransformDirection(Vector3.down); 
        RaycastHit ray = new RaycastHit();
        
        Debug.DrawRay(rb.position, down, Color.green);

        if (Physics.Raycast(rb.position, down, out ray, .25f))
        {
            if (ray.collider.CompareTag("Ground"))
            {
                lives -= 1;

               
                

            }

        }

        switch (lives)
        {
            case 3:
                L1.gameObject.SetActive(true);
                L2.gameObject.SetActive(true);
                L3.gameObject.SetActive(true);
                break; 
            case 2:
                L1.gameObject.SetActive(true);
                L2.gameObject.SetActive(true);
                L3.gameObject.SetActive(false);
                break;
            case 1:
                L1.gameObject.SetActive(true);
                L2.gameObject.SetActive(false);
                L3.gameObject.SetActive(false);
                break; 
            case 0:
                Debug.Log("Game Over");
                break; 
        }

      
    }


    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Scroll"))
        {
            Debug.Log("hit");
            var transform1 = transform;
            transform1.localPosition = new Vector3(0, transform1.position.y, 0); 
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("hit circle");
            points +=  25; 
        }
    }
}
