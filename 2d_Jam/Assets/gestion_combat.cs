using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gestion_combat : MonoBehaviour
{

    public static int enemie_tag = 0;
    public GameObject bullet;
    public GameObject bullet_hold;

    public GameObject Player;
    public int bullet_speed=50;

    [Header("Choix_Vague_ennemie")]

    public List<int> Enne_tag_0;
    public List<int> Enne_tag_1;
    public List<int> Enne_tag_2;
    public List<int> Enne_tag_3;

    public static int Ennemie_live=3;
    public Text ennemie_life;

    public static float BS=0;
    public int conter_down = 10;
    public float conter_restart=15;
    public int random_pick=0;
    private List<int> rd_;

    public bool Fire_engage = false;
    public bool Fire_switch = false;

    public System.Random rnd = new System.Random();
    [Header("Wave_1")]
    public bool norm_wave = false;
    private int conter_norm_wave = -1;
    public int speed_respawn = 20;

    [Header("Wave_2")]
    public GameObject prev_laser;
    public GameObject Lazer;
    public bool laser_wave = false;
    public int conter_laser_wave = -1;
    public int speed_respawn_laser=50;
    public static int speed_respawn_laser_static = 0;
    public bool prevl_laser=false;
    public int _laser_random = 1;
    public float random_x = 0;
    public float random_y = 0;

    Vector3 dir = Vector3.zero;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player_move.Combat)
        {
            ennemie_life.text = "Ennemie: " + Ennemie_live.ToString();
        }
        else
        {
            ennemie_life.text = "";
        }
        
        if(Ennemie_live==-1)
        {
            player_move.Combat = false;
            Ennemie_live = 3;
        }
        if (enemie_tag==0)
        {
            rd_ =Enne_tag_0;
        }
        if (enemie_tag == 1)
        {
            rd_ = Enne_tag_1;
        }
        if (enemie_tag == 2)
        {
            rd_ = Enne_tag_2;
        }
        if (enemie_tag == 3)
        {
            rd_ = Enne_tag_3;
        }
        speed_respawn_laser_static = speed_respawn_laser;
        BS = bullet_speed;
        if(conter_down<=0)
        {
            Fire_switch = true;
            conter_down = (int)conter_restart * 60;
        }
        if(Fire_switch)
        {
            if(Fire_engage)
            {
                if(random_pick+1<rd_.Count)
                    random_pick++;
                else
                {
                    random_pick = 0;
                }
            }
            else
            {
                Ennemie_live--;
            }

            Fire_engage = !Fire_engage;
            Fire_switch = false;
            conter_norm_wave = speed_respawn;
            conter_laser_wave = speed_respawn_laser;
            prevl_laser = true;
        }
        if(Fire_engage)
        {
            
            
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
       
        switch(rd_[random_pick])
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
                    b.transform.position = new Vector3(-2.5f, Random.Range(-2.5f,5.5f), 0);
                    dir = Vector3.right;
                    break;
                case 2:
                    b.transform.position = new Vector3(2.5f, Random.Range(-2.5f, 5.5f), 0);
                    dir = Vector3.left;
                    break;
                case 3:
                    b.transform.position = new Vector3(Random.Range(-2.5f, 5.5f), -2.5f, 0);
                    dir = Vector3.up;
                    break;
                case 4:
                    b.transform.position = new Vector3(Random.Range(-2.5f, 5.5f), 2.5f, 0);
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
        if (prevl_laser)
        {
            _laser_random = rnd.Next(0,3);
            random_x = Random.Range(-2, 2);
            random_y = Random.Range(-2, 2);
            prevl_laser = false;
            
                
                
            
        }
        if(conter_laser_wave==30)
        {
            if (_laser_random == 1)
            {

                GameObject c = Instantiate(prev_laser);
                c.transform.rotation = Quaternion.Euler(0f, 0, 90);
                c.transform.position = new Vector3(0, random_y, 0);
            }
            else
            {
                GameObject g = Instantiate(prev_laser);
                g.transform.Rotate(0f, 0, 0f);
                g.transform.position = new Vector3(random_x, 0, 0);
            }
        }
        
        if (conter_laser_wave == 0)
        {
                if(_laser_random==1)
                {
                    GameObject b = Instantiate(Lazer);
                    b.transform.rotation = Quaternion.Euler(0, 0, 90);
                    b.transform.position = new Vector3(0, random_y, 0);
                }
                else
                {
                    GameObject f = Instantiate(Lazer, Vector3.zero, Quaternion.Euler(0, 0, 0), transform);
                    f.transform.position = new Vector3(random_x, 0, 0);
                }

                prevl_laser = true;
                conter_laser_wave = speed_respawn_laser;

        }
        
    }
}
