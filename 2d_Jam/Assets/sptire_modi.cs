using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sptire_modi : MonoBehaviour
{

    public Sprite Ennemie_0;
    public Sprite Ennemie_1;
    public Sprite Ennemie_2;
    public Sprite Ennemie_3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gestion_combat.enemie_tag == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Ennemie_0;
        }
        if (gestion_combat.enemie_tag == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Ennemie_1;
        }
        if (gestion_combat.enemie_tag == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Ennemie_2;
        }
        if (gestion_combat.enemie_tag == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Ennemie_3;
        }
    }
}
