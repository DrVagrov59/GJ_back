using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coltest : MonoBehaviour
{
    public static bool walk=true; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag!="no_Walkable")
        {
            walk = false;
        }
    }
}
