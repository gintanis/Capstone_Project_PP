using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BreathControl : MonoBehaviour
{
    [Header("BREATH")] 
    //add to list later
    public float inB;
    public float holdB;
    public float outB;
    public List<float> _timers = new List<float>();
    public bool outBreath;
    private float micInput;
    public GameObject bTimer;
    public Text bT;


    public float deductCounter; 
    public float pointDeduct;
    public bool deduct; 
    public PlayerControl pC;
    public GameObject pControl; 


    private void Awake()
    {
        deductCounter = 0;
        pointDeduct = 2; 
        
        inB = 4f;
        holdB = 7f;
        outB = 8f; 
            
        _timers.Add(inB );
        _timers.Add(holdB);
        _timers.Add(outB);
        
        
        pC = pControl.GetComponent<PlayerControl>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if (!outBreath)
        {

            _timers[0] -= Time.deltaTime;
            bT.text = "In: " + Mathf.Round(_timers[0]);

        }
        if (_timers[0] <= 0 && !outBreath)
        {
            _timers[2] = outB; 
            _timers[1] -= Time.deltaTime;
            bT.text = "Hold: " + Math.Round(_timers[1]);
        }
        if (_timers[1] <= 0)
        {
            
            outBreath = true; 
        }

        if (outBreath)
        {
            _timers[0] = inB;
            _timers[1] = holdB; 
            
            _timers[2] -= Time.deltaTime;
            bT.text = "Out: " + Math.Round(_timers[2]);
        }
        if (outBreath && !pC.IsBreathingOut)
        {
            deductCounter += 1 * Time.deltaTime;
        }
        if (_timers[2] <= 0)
        {
            outBreath = false;
            pC.points -= deductCounter * pointDeduct; 
            deductCounter = 0; 
        }


        






    }


  
}
