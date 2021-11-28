using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLandscape : MonoBehaviour
{

    [Header("Plane")]
    

    public GameObject pF; 
    public float dis;
    public int gridX;
    public int gridZ;

    
    void Awake()
    {
        gridX = 10;
        gridZ = 15;
       // pF = pF.GetComponent<GameObject>();



        for (int i = 0; i < gridX; i++)
        {
            for (int j = 0; j < gridZ; j++)
            {
                Vector3 position = new Vector3(i, 0, j) * dis;
                Instantiate(pF, position, Quaternion.identity); 
            }
        }
        
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }
}
