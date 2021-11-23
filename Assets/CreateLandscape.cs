using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLandscape : MonoBehaviour
{

    [Header("Plane")]
    public GameObject planePrefab;
    private Plane _plane;

    public int grid; 

    
    void Awake()
    {
        _plane = planePrefab.GetComponent<Plane>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
