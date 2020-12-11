using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemie_kill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player_move.Combat)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (player_move.Combat)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
        //private void OnTriggerStay2D(Collider2D collision)
        //{
        //    if(collision.gameObject.tag=="Respawn"&&gestion_combat.Ennemie_live==0)
        //    {
        //        Destroy(gameObject);
        //    }
        //}
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            Destroy(gameObject);
        }
    }
}
