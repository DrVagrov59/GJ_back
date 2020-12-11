using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_battle : MonoBehaviour
{
    public float speed=2;
    public Text lif_holder;
    public int Life=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lif_holder.text = "Player: "+Life.ToString();
    }
    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position+=new Vector3(-speed*Time.deltaTime,0,0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet"||collision.gameObject.tag=="Laser")
        {
            Life--;
            Destroy(collision.gameObject);
        }
    }
 
}
