using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public static enemyHealth instance;
    private Animator anim;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int amount)
    {
        health -= amount;
        StartCoroutine(animationControl.instance.animHit(.35f));
        
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    /*
    IEnumerator animationHit()
    {
        anim.SetBool("isHit", true);
        yield return new WaitForSeconds(.35f);
        anim.SetBool("isHit", false);
    }
    */
}
