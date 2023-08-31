using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBulletDamage : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log(damage);
            Destroy(gameObject);

            collision.gameObject.GetComponent<enemyController>().Damage(damage, .35f);
        } 
        if(collision.gameObject.tag == "walls")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "health")
        {
            Destroy(gameObject);

            Destroy(collision.gameObject);

            playerHealthController.instance.healthChange(true, false, 10);
        }
    }
}
