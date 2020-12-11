using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_holder : MonoBehaviour
{
    public float speed = 0;
    private Vector3 player_dir;
    public GameObject player_base;
    public Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 20);
        speed = gestion_combat.BS;
        GameObject[] ffds = GameObject.FindGameObjectsWithTag("Player");  //returns GameObject[]
        foreach (GameObject item in ffds)
        {
            if (item.GetComponent("player_battle"))
            {
                player_base = item;

            }
        }
        player_dir = player_base.transform.position;
        dir = new Vector3(player_dir.x-transform.position.x,player_dir.y-transform.position.y,0);
        gameObject.GetComponent<Rigidbody2D>().AddForce(dir.normalized*speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
