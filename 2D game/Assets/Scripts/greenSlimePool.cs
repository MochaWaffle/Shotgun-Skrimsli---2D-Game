using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenSlimePool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "player")
        {
            GameObject.Find("GameManager").GetComponent<enemyController>().Attack(5, .5f);
            //StartCoroutine(deathPoisionPoolStay(.5f));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            GameManager.instance.deathPosionPoolActivate();
        }
        
    }

    public IEnumerator deathPoisionPoolStay(float poisionRate)
    {
        Debug.Log("one");

        yield return new WaitForSeconds(poisionRate);

        Debug.Log("one");
    }
}
