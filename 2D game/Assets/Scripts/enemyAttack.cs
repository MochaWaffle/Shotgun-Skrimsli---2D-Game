using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public void Attack(int amount)
    {
        playerHealthController.instance.healthNumber -= amount;
        StartCoroutine(animationHit());

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
    }
}
