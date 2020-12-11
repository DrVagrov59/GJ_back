using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_code : MonoBehaviour
{
    public float time_destruct = 3;
    public float SCR;
    // Start is called before the first frame update
    void Start()
    {
        SCR = gestion_combat.speed_respawn_laser_static/3;
        SCR /= 60;

        Destroy(gameObject, SCR);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
