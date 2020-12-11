using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestion_combat : MonoBehaviour
{
    public static int enemie_tag = 42;
    public GameObject bullet;
    public GameObject bullet_hold;
    public GameObject Player;
    public int bullet_speed=50;

    public static float BS=0;
    public int conter_down = 10;
    public float conter_restart=15;
    public int random_pick=0;
    public bool Fire_engage = false;
    public bool Fire_switch = false;

    public System.Random rnd = new System.Random();
    [Header("Wave_1")]
    public bool norm_wave = false;
    private int conter_norm_wave = -1;
    public int speed_respawn = 20;

    [Header("Wave_2")]
    public bool laser_wave = false;
    private int conter_laser_wave = -1;
    public int speed_respawn_laser=50;

    Vector3 dir = Vector3.zero;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BS = bullet_speed;
        if(conter_down<=0)
        {
            Fire_switch = true;
            conter_down = (int)conter_restart * 60;
        }
        if(Fire_switch)
        {
            Fire_engage = !Fire_engage;
            Fire_switch = false;
            conter_norm_wave = speed_respawn;
            conter_laser_wave = speed_respawn_laser;
        }
        if(Fire_engage)
        {
            random_pick = 0;
            
            Fire();
        }
    }
    private void FixedUpdate()
    {
        conter_down--;

        if (norm_wave)
        {
            conter_norm_wave--;
        }
        if(laser_wave)
        {
            conter_laser_wave--;
        }
    }
    void Fire()
    {

        // random_pick = (int)Random.Range(0f,1.9f);
       
        switch(random_pick)
        {
            case 0:
                Fire_normal_bullet(speed_respawn);

                break;
            case 1:

                Fire_Laser_wave(speed_respawn_laser);
                break;






        }



    }
    void Fire_normal_bullet(int duration)
    {
        norm_wave = true;
        if(conter_norm_wave==0)
        {
            GameObject b = Instantiate(bullet);
            int random = rnd.Next(1, 4);

            switch (random)
            {
                case 1:
                    b.transform.position = new Vector3(-2.5f, Random.Range(-2.5f,5.5f), 1);
                    dir = Vector3.right;
                    break;
                case 2:
                    b.transform.position = new Vector3(2.5f, Random.Range(-2.5f, 5.5f), 1);
                    dir = Vector3.left;
                    break;
                case 3:
                    b.transform.position = new Vector3(Random.Range(-2.5f, 5.5f), -2.5f, 1);
                    dir = Vector3.up;
                    break;
                case 4:
                    b.transform.position = new Vector3(Random.Range(-2.5f, 5.5f), 2.5f, 1);
                    dir = Vector3.down;
                    break;
            }
            b.GetComponent<Rigidbody2D>().AddForce(dir.normalized * bullet_speed);
            conter_norm_wave = duration;
        }

       
    }
    void Fire_Laser_wave(int duration)
    {
        laser_wave = true;
        if(conter_laser_wave==0)
        {

        }
    }
}
