using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationControl : MonoBehaviour
{
    public static animationControl instance;
    public static Animator anim;
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

    public IEnumerator animHit(float waitForSecond)
    {
        if(anim.GetBool("isHit") == false)
        {
            anim.SetBool("isHit", true);
        }

        yield return new WaitForSeconds(waitForSecond);

        anim.SetBool("isHit", false);
    }
}
