using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{

    public Vector3 pos_pres;
    public GameObject Combat_Zone;

    public float speed;
    public static bool Combat=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Combat)
        {
            player_move_();
            Combat_Zone.SetActive(false);
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            Combat_Zone.SetActive(true);
            gameObject.GetComponent<Collider2D>().enabled = false;
        }

       



    }
    void player_move_()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!check_pres(transform.position + Vector3.down, Vector3.down))
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.down, speed);
            }

        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!check_pres(transform.position + Vector3.up, Vector3.up))
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.up, speed);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if(!check_pres(transform.position+Vector3.left, Vector3.left))
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.left, speed);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!check_pres(transform.position + Vector3.right, Vector3.right))
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.right, speed);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Ennemie_0")
        {
            Combat = true;
            gestion_combat.enemie_tag = 0;
        }
        if (collision.gameObject.tag == "Ennemie_1")
        {
            Combat = true;
            gestion_combat.enemie_tag = 1;
        }
        if (collision.gameObject.tag == "Ennemie_2")
        {
            Combat = true;
            gestion_combat.enemie_tag = 3;
        }
        if (collision.gameObject.tag == "Ennemie_3")
        {
            Combat = true;
            gestion_combat.enemie_tag = 3;
        }
    }
    static bool check_pres(Vector3 pos,Vector3 dir)
    {
        RaycastHit2D hitpos = Physics2D.CircleCast(pos, 0.2f, dir.normalized, 0.1f);

        Debug.DrawLine(pos + new Vector3(-0.1f, 0, 0), pos + new Vector3(0.1f, 0, 0), Color.red, 2) ;
        Debug.DrawLine(pos + new Vector3(0, -0.1f, 0), pos + new Vector3(0, 0.1f, 0), Color.red, 2);
        if (hitpos.collider!=null)
        {
            
            if (hitpos.collider.gameObject.tag == "no_Walkable")
            {
               
                return true;
                
            }
            else
            {
               
                return false;
            }
        }
        else
        {
            return false;
        }
        
        //if (!coltest.walk)
        //{

        //    pos_objectif.transform.position = pos_pres;
        //    coltest.walk = true;
        //}
    }
    void Combat_in()
    {

    }
}
