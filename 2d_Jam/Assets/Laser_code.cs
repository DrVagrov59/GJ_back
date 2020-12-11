using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_code : MonoBehaviour
{
    public float time_destruct = 3;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time_destruct);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
