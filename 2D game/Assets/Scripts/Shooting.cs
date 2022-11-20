using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public static Shooting instance;

    //shotugn spark area
    public Transform shotgunFireSpark;
    public GameObject shotgunFireSparkObject;

    //revolver spark area
    public Transform revolverFireSpark;
    public GameObject revolverFireSparkObject;

    //left click firePoints (shotty)
    public Transform LshotgunFirePoint;
    public Transform LshotgunFirePoint2;
    public Transform LshotgunFirePoint3;
    /*public Transform LshotgunFirePointFlipped;
    public Transform LshotgunFirePointFlipped2;
    public Transform LshotgunFirePointFlipped3;
    public Transform LshotgunFirePointNotFlipped;
    public Transform LshotgunFirePointNotFlipped2;
    public Transform LshotgunFirePointNotFlipped3;*/

    //right click firePoints (shotty)
    public Transform RshotgunFirePoint4;
    public Transform RshotgunFirePoint5;
    public Transform RshotgunFirePoint6;
    public Transform RshotgunFirePoint7;
    public Transform RshotgunFirePoint8;
    public Transform RshotgunFirePoint9;
    /*public Transform RshotgunFirePointFlipped4;
    public Transform RshotgunFirePointFlipped5;
    public Transform RshotgunFirePointFlipped6;
    public Transform RshotgunFirePointFlipped7;
    public Transform RshotgunFirePointFlipped8;
    public Transform RshotgunFirePointFlipped9;
    public Transform RshotgunFirePointNotFlipped4;
    public Transform RshotgunFirePointNotFlipped5;
    public Transform RshotgunFirePointNotFlipped6;
    public Transform RshotgunFirePointNotFlipped7;
    public Transform RshotgunFirePointNotFlipped8;
    public Transform RshotgunFirePointNotFlipped9;*/

    public Transform revolverFirePoint;
    /*public Transform revolverFirePointFlipped;
    public Transform revolverFirePointNotFlipped;*/
    public GameObject bulletPrefab;
    public GameObject bulletPrefab1;

    public float shotgunBulletForce = 20f;
    public float revolverBulletForce = 20f;
    public float shotgunShake = 2f;
    public float revolverShake = 1f;
    public int shotgunAmmo = 2;
    public int shotgunAmmoReset;
    public int revolverAmmo = 10;
    public int revolverAmmoReset;
    public float shotgunReloadTime = 2f;
    public float revolverReloadTime = 1f;
    public float revolverFireRate = .2f;
    public float shotgunFireRate = .5f;
    //public float shotgunFireRate = 50f;
    //public float revolverFireRate = 50f;
    //private float shotgunFireRateReset;
    //private float revolverFireRateReset;
    public bool shotgunFireRateOn = false;
    public bool revolverFireRateOn = false;
    public bool shotgunReloadOn = false;
    public bool revolverReloadOn = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        shotgunAmmoReset = shotgunAmmo;
        revolverAmmoReset = revolverAmmo;
        //shotgunFireRateReset = shotgunFireRate;
        //revolverFireRateReset = revolverFireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.pauseScreenOn == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot(true);
            }
            if (Input.GetButtonDown("Fire2"))
            {
                Shoot(false);
            }
        }
    }

    public void Shoot(bool leftClick)
    {
        if(leftClick == true)
        {
            if (playerController.instance.shotgunOn == true && shotgunAmmo > 0 && shotgunFireRateOn == false && shotgunReloadOn == false)
            {
                shootMethod(true, false, false);
                cineMachineShake.instance.ShakeCamera(shotgunShake, 0.1f);
                shotgunAmmo -= 1;
                shotgunFireRateOn = true;
                StartCoroutine(sparkShow(true, false));
                StartCoroutine(weaponFireRate(true, false));
                if(shotgunAmmo <= 0)
                {
                    StartCoroutine(Reload(true, false));
                } else
                {
                    playerController.instance.ammoText.text = "AMMO: " + shotgunAmmo + "/" + shotgunAmmoReset;
                }

            }
            if (playerController.instance.revolverOn == true && revolverAmmo > 0 && revolverFireRateOn == false && revolverReloadOn == false)
            {
                shootMethod(false, false, true);
                cineMachineShake.instance.ShakeCamera(revolverShake, 0.1f);
                revolverAmmo -= 1;
                revolverFireRateOn = true;
                StartCoroutine(sparkShow(false, true));
                StartCoroutine(weaponFireRate(false, true));
                if(revolverAmmo <= 0)
                {
                    StartCoroutine(Reload(false, true));
                } else
                {
                    playerController.instance.ammoText.text = "AMMO: " + revolverAmmo + "/" + revolverAmmoReset;
                }
            }
        } else
        {
            if(playerController.instance.shotgunOn == true && shotgunFireRateOn == false && shotgunReloadOn == false)
            {
                if(shotgunAmmo == 2)
                {
                    shootMethod(false, true, false);
                    cineMachineShake.instance.ShakeCamera(shotgunShake * 2, 0.1f);
                    shotgunAmmo -= 2;
                    StartCoroutine(sparkShow(true, false));
                    StartCoroutine(Reload(true, false));
                } else if(shotgunAmmo > 0)
                {
                    shootMethod(true, false, false);
                    cineMachineShake.instance.ShakeCamera(shotgunShake, 0.1f);
                    shotgunAmmo -= 1;
                    StartCoroutine(sparkShow(true, false));
                    shotgunFireRateOn = true;
                    StartCoroutine(weaponFireRate(true, false));
                    if(shotgunAmmo == 0)
                    {
                        StartCoroutine(Reload(true, false));
                    }
                }
            }
        }
        
        if(playerController.instance.isHit == true)
        {
            playerController.instance.isHit = false;
        }
    }

    void shootMethod(bool shotGunFireLeft, bool shotgunFireRight, bool revolverGunFire)
    {
        if(shotGunFireLeft == true)
        {
            shoot(LshotgunFirePoint, bulletPrefab, shotgunBulletForce);
            shoot(LshotgunFirePoint2, bulletPrefab, shotgunBulletForce);
            shoot(LshotgunFirePoint3, bulletPrefab, shotgunBulletForce);
            //shoot(firepoint);
            //shoot(firepoint);
        }
        if(shotgunFireRight == true)
        {
            shoot(LshotgunFirePoint, bulletPrefab, shotgunBulletForce);
            shoot(RshotgunFirePoint4, bulletPrefab, shotgunBulletForce);
            shoot(RshotgunFirePoint5, bulletPrefab, shotgunBulletForce);
            shoot(RshotgunFirePoint6, bulletPrefab, shotgunBulletForce);
            shoot(RshotgunFirePoint7, bulletPrefab, shotgunBulletForce);
            shoot(RshotgunFirePoint8, bulletPrefab, shotgunBulletForce);
            shoot(RshotgunFirePoint9, bulletPrefab, shotgunBulletForce);
        }
        if(revolverGunFire == true)
        {
            shoot(revolverFirePoint, bulletPrefab1, revolverBulletForce);
        }
    }

    void shoot(Transform firepoint, GameObject bulletPrefab, float bulletForce)
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
    }

    public IEnumerator Reload(bool shotgunReload, bool revolverReload)
    {
        if(shotgunReload == true)
        {
            shotgunReloadOn = true;

            if(playerController.instance.shotgunOn == true)
            {
                playerController.instance.ammoText.text = "AMMO: " + shotgunAmmo + "/" + shotgunAmmoReset;
            }
            
            yield return new WaitForSeconds(0.5f);

            if(playerController.instance.shotgunOn == true)
            {
                playerController.instance.ammoText.text = "AMMO: Reloading..";
            }
            

            yield return new WaitForSeconds(shotgunReloadTime);

            shotgunAmmo = shotgunAmmoReset;

            if(playerController.instance.shotgunOn == true)
            {
                playerController.instance.ammoText.text = "AMMO: " + shotgunAmmo + "/" + shotgunAmmoReset;
            }
            
            shotgunReloadOn = false;
        }
        if(revolverReload == true)
        {
            revolverReloadOn = true;

            if(playerController.instance.revolverOn == true)
            {
                playerController.instance.ammoText.text = "AMMO: " + revolverAmmo + "/" + revolverAmmoReset;
            }
            
            yield return new WaitForSeconds(0.5f);

            if(playerController.instance.revolverOn == true)
            {
                playerController.instance.ammoText.text = "AMMO: Reloading..";
            }
            

            yield return new WaitForSeconds(revolverReloadTime);

            revolverAmmo = revolverAmmoReset;

            if(playerController.instance.revolverOn == true)
            {
                playerController.instance.ammoText.text = "AMMO: " + revolverAmmo + "/" + revolverAmmoReset;
            }
            revolverReloadOn = false;
        }
    }
    IEnumerator weaponFireRate(bool shotgun, bool revolver)
    {
        if(shotgun == true)
        {
            
            yield return new WaitForSeconds(shotgunFireRate);
            shotgunFireRateOn = false;
            
        } else if (revolver == true)
        {
            yield return new WaitForSeconds(revolverFireRate);
            revolverFireRateOn = false;
        }
    }
    IEnumerator sparkShow(bool shotgun, bool revolver)
    {
        if(shotgun == true)
        {
            shotgunFireSparkObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            shotgunFireSparkObject.SetActive(false);
        }
        if(revolver == true)
        {
            revolverFireSparkObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            revolverFireSparkObject.SetActive(false);
        }
    }
}
