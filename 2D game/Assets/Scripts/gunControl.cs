using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunControl : MonoBehaviour
{
    public static gunControl instance;

    public SpriteRenderer gunSpriteRend;

    public Transform gun;

    public Transform player;
    public bool gunMove = false;

    public float shotgunFirePointY = -1.98f;

    public float shotgunFirePointYFlipped = -2.279087f;

    public float revolverFirePointY = 0.124f;

    public float shotgunFireSparkPointY = 0.12f;

    public float shotgunFireSparkPointYFlipped = -0.1f;

    public float revolverFireSparkPointY = 0.121f;

    public float gunX;
    public float gunXFlipped;
    /*private float gunX = 0.28f;
    private float shotgunFirePointYNotFlipped = 0.15f;
    private float revolverFirePointNotFlipped = 0.124f;
    private float revolverFirePointFlipped = 0.2f;*/
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //rotation
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (GameManager.instance.pauseScreenOn == false)
        {
            if (angle < 89 && angle > -89)
            {
                flipGun(false);
                //Shooting.instance.shotgunFirePoint.transform.position = new Vector3(0f, shotgunFirePointYNotFlipped, 0f);
            } else
            {
                flipGun(true);
                //Shooting.instance.shotgunFirePoint.transform.position = new Vector3(0f, -shotgunFirePointYNotFlipped, 0f);
            }
            /*if(gunMove == true)
            {
            
            }*/
        
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        /*if(transform.rotation.eulerAngles.z >= 90 || transform.rotation.eulerAngles.z <= 90)
        {
            gunSpriteRend.flipX = true;
        }*/
        //Debug.Log(angle);
    }

    private void flipGun(bool flip)
    {
        gunSpriteRend.flipY = flip;

        if(flip == false)
        {
            // moves the gun to the right
            gun.localPosition = new Vector3(gunX, gun.localPosition.y, gun.localPosition.z);

            //flips shotgun firepoints to the right side firepoints (For left click)
            Shooting.instance.LshotgunFirePoint.localPosition = new Vector3(Shooting.instance.LshotgunFirePoint.localPosition.x, shotgunFirePointY, Shooting.instance.LshotgunFirePoint.localPosition.z);
            Shooting.instance.LshotgunFirePoint2.localPosition = new Vector3(Shooting.instance.LshotgunFirePoint2.localPosition.x, shotgunFirePointY, Shooting.instance.LshotgunFirePoint2.localPosition.z);
            Shooting.instance.LshotgunFirePoint3.localPosition = new Vector3(Shooting.instance.LshotgunFirePoint3.localPosition.x, shotgunFirePointY, Shooting.instance.LshotgunFirePoint3.localPosition.z);

            //flips shotgun firepoints to the right side firepoints (For right click)
            Shooting.instance.RshotgunFirePoint4.localPosition = new Vector3(Shooting.instance.RshotgunFirePoint4.localPosition.x, shotgunFirePointY, Shooting.instance.RshotgunFirePoint4.localPosition.z);
            Shooting.instance.RshotgunFirePoint5.localPosition = new Vector3(Shooting.instance.RshotgunFirePoint5.localPosition.x, shotgunFirePointY, Shooting.instance.RshotgunFirePoint5.localPosition.z);
            Shooting.instance.RshotgunFirePoint6.localPosition = new Vector3(Shooting.instance.RshotgunFirePoint6.localPosition.x, shotgunFirePointY, Shooting.instance.RshotgunFirePoint6.localPosition.z);
            Shooting.instance.RshotgunFirePoint7.localPosition = new Vector3(Shooting.instance.RshotgunFirePoint7.localPosition.x, shotgunFirePointY, Shooting.instance.RshotgunFirePoint7.localPosition.z);
            Shooting.instance.RshotgunFirePoint8.localPosition = new Vector3(Shooting.instance.RshotgunFirePoint8.localPosition.x, shotgunFirePointY, Shooting.instance.RshotgunFirePoint8.localPosition.z);
            Shooting.instance.RshotgunFirePoint9.localPosition = new Vector3(Shooting.instance.RshotgunFirePoint9.localPosition.x, shotgunFirePointY, Shooting.instance.RshotgunFirePoint9.localPosition.z);

            //flips revolver firepoints to the right side firepoints (For left click)
            Shooting.instance.revolverFirePoint.localPosition = new Vector3(Shooting.instance.revolverFirePoint.localPosition.x, revolverFirePointY, Shooting.instance.revolverFirePoint.localPosition.z);

            //flips shotgun spark to the right side (default)
            //Shooting.instance.shotgunFireSpark = Shooting.instance.RightShotgunFireSpark;
            //Shooting.instance.shotgunFireSparkObject = Shooting.instance.shotgunFireSparkObjectRight;
            Shooting.instance.shotgunFireSpark.localPosition = new Vector3(Shooting.instance.shotgunFireSpark.localPosition.x, 0.12f, Shooting.instance.shotgunFireSpark.localPosition.z);

            //flips revolver spark to the right 
            Shooting.instance.revolverFireSpark.localPosition = new Vector3(Shooting.instance.revolverFireSpark.localPosition.x, revolverFireSparkPointY, Shooting.instance.revolverFireSpark.localPosition.z);
        }
        if (flip == true)
        {
            gun.localPosition = new Vector3(gunXFlipped, gun.localPosition.y, gun.localPosition.z);

            //flips shotgun firepoints to the left side firepoints (For left click)
            Shooting.instance.LshotgunFirePoint.localPosition = new Vector3(Shooting.instance.LshotgunFirePoint.localPosition.x, shotgunFirePointYFlipped, Shooting.instance.LshotgunFirePoint.localPosition.z);
            Shooting.instance.LshotgunFirePoint2.localPosition = new Vector3(Shooting.instance.LshotgunFirePoint2.localPosition.x, shotgunFirePointYFlipped, Shooting.instance.LshotgunFirePoint2.localPosition.z);
            Shooting.instance.LshotgunFirePoint3.localPosition = new Vector3(Shooting.instance.LshotgunFirePoint3.localPosition.x, shotgunFirePointYFlipped, Shooting.instance.LshotgunFirePoint3.localPosition.z);

            //flips shotgun firepoints to the left side firepoints (For right click)
            Shooting.instance.RshotgunFirePoint4.localPosition = new Vector3(Shooting.instance.RshotgunFirePoint4.localPosition.x, shotgunFirePointYFlipped, Shooting.instance.RshotgunFirePoint4.localPosition.z);
            Shooting.instance.RshotgunFirePoint5.localPosition = new Vector3(Shooting.instance.RshotgunFirePoint5.localPosition.x, shotgunFirePointYFlipped, Shooting.instance.RshotgunFirePoint5.localPosition.z);
            Shooting.instance.RshotgunFirePoint6.localPosition = new Vector3(Shooting.instance.RshotgunFirePoint6.localPosition.x, shotgunFirePointYFlipped, Shooting.instance.RshotgunFirePoint6.localPosition.z);
            Shooting.instance.RshotgunFirePoint7.localPosition = new Vector3(Shooting.instance.RshotgunFirePoint7.localPosition.x, shotgunFirePointYFlipped, Shooting.instance.RshotgunFirePoint7.localPosition.z);
            Shooting.instance.RshotgunFirePoint8.localPosition = new Vector3(Shooting.instance.RshotgunFirePoint8.localPosition.x, shotgunFirePointYFlipped, Shooting.instance.RshotgunFirePoint8.localPosition.z);
            Shooting.instance.RshotgunFirePoint9.localPosition = new Vector3(Shooting.instance.RshotgunFirePoint9.localPosition.x, shotgunFirePointYFlipped, Shooting.instance.RshotgunFirePoint9.localPosition.z);

            //flips shotgun firepoints to the left side firepoints (For left click)
            Shooting.instance.revolverFirePoint.localPosition = new Vector3(Shooting.instance.revolverFirePoint.localPosition.x, -revolverFirePointY, Shooting.instance.revolverFirePoint.localPosition.z);

            //flips shotgun spark to the left (not default, it's the flipped version aka -y of the default y for the non flipped (default) shotgun spark)
            //Shooting.instance.shotgunFireSpark = Shooting.instance.LeftShotgunFireSpark;
            //Shooting.instance.shotgunFireSparkObject = Shooting.instance.shotgunFireSparkObjectLeft;
            Shooting.instance.shotgunFireSpark.localPosition = new Vector3(Shooting.instance.shotgunFireSpark.localPosition.x, shotgunFireSparkPointYFlipped, Shooting.instance.shotgunFireSpark.localPosition.z);

            //flips revolver spark to the left
            Shooting.instance.revolverFireSpark.localPosition = new Vector3(Shooting.instance.revolverFireSpark.localPosition.x, -revolverFireSparkPointY, Shooting.instance.revolverFireSpark.localPosition.z);
        }
    }
}
