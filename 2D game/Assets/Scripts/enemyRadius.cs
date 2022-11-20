using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRadius : MonoBehaviour
{
    public Rigidbody2D rb;

    //public bool playerClose = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(playerClose == false)
        {
            rb.bodyType = RigidbodyType2D.Static;
        } else if (playerClose == true)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            //playerClose = true;
            //rb.bodyType = RigidbodyType2D.Dynamic;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            //playerClose = false;
            //rb.bodyType = RigidbodyType2D.Static;
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
