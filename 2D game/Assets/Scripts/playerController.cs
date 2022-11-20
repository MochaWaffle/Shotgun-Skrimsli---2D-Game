using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerController : MonoBehaviour
{
    public int dashDamage;

    public float moveSpeed = 5f;
    public float dashLength;
    public float dashSpeed;
    public float dashReset;

    private float moveSpeedNormal;

    public bool shotgunOn = false;
    public bool revolverOn = false;
    public bool isHit = false;
    public bool playerCanDash = true;

    public Rigidbody2D rb;
    public GameObject shotgun;
    public GameObject revolver;
    public static playerController instance;

    public Image shotGunImage;
    public Image revolverImage;
    public Image screenBlood;

    public Text ammoText;
    public Animator anim;
    private Vector2 movement;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        moveSpeedNormal = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, moveY).normalized;

        if (GameManager.instance.pauseScreenOn == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && playerCanDash == true)
            {
                StartCoroutine(playerDash(dashLength, dashSpeed, dashReset, dashDamage));
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) && shotgunOn == false)
            {
                switchGuns(true, false);
            } else if (Input.GetKeyDown(KeyCode.Alpha1) && shotgunOn == true)
            {
                switchGuns(false, false);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && revolverOn == false)
            {
                switchGuns(false, true);
            } else if (Input.GetKeyDown(KeyCode.Alpha2) && revolverOn == true)
            {
                switchGuns(false, false);
            }

            if(Input.GetKeyDown(KeyCode.R))
            {
                if(shotgunOn == true && Shooting.instance.shotgunAmmo < 2 && Shooting.instance.shotgunReloadOn == false)
                {
                    Shooting.instance.StartCoroutine(Shooting.instance.Reload(true, false));
                } else if (revolverOn == true && Shooting.instance.revolverAmmo < 10 && Shooting.instance.revolverReloadOn == false)
                {
                    Shooting.instance.StartCoroutine(Shooting.instance.Reload(false, true));
                }
            }
        }
        if (isHit == false)
        {
            anim.SetBool("isHit", false);
            screenBlood.color = new Color32(255, 0, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void switchGuns(bool shotgunActive, bool revolverActive)
    {
        shotgun.SetActive(shotgunActive);
        revolver.SetActive(revolverActive);

        if(shotgunActive == true)
        {
            changeColor(shotGunImage, 0, 255, 0, 255);
            shotgunOn = true;
            if(shotgunOn == true)
            {
                if(Shooting.instance.shotgunReloadOn == false)
                {
                    ammoText.text = "AMMO: " + Shooting.instance.shotgunAmmo + "/" + Shooting.instance.shotgunAmmoReset;
                } else
                {
                    ammoText.text = "AMMO: Reloading..";
                }
            } 
            
        } else if(shotgunActive == false)
        {
            changeColor(shotGunImage, 255, 255, 255, 255);
            shotgunOn = false;
        }

        if(revolverActive == true)
        {
            changeColor(revolverImage, 0, 255, 0, 255);
            revolverOn = true;
            if(revolverOn == true)
            {
                if(Shooting.instance.revolverReloadOn == false)
                {
                    ammoText.text = "AMMO: " + Shooting.instance.revolverAmmo + "/" + Shooting.instance.revolverAmmoReset;
                } else
                {
                    ammoText.text = "AMMO: Reloading..";
                }
            }
            
        } else if (revolverActive == false)
        {
            changeColor(revolverImage, 255, 255, 255, 255);
            revolverOn = false;
        }
        if(shotgunActive == false && revolverActive == false)
        {
            ammoText.text = "AMMO: -";
        }
    }

    private void changeColor(Image gunBackgroundColor, byte r, byte g, byte b, byte a)
    {
        // grey color = 180 for all
        // green color = 66, 221, 72, 255 for all

        /*if(shotGun == true)
        {
           shotGunImage.color = new Color32(66, 221, 72, 255);
        } else
        {
            shotGunImage.color = new Color32(180, 180, 180, 255);
        }

        if(revolver == true)
        {
            revolverImage.color = new Color32(66, 221, 72, 255);
        } else
        {
            revolverImage.color = new Color32(180, 180, 180, 255);
        }*/
        gunBackgroundColor.color = new Color32(r, g, b, a);
    }
    public IEnumerator playerHit(float waitForSeconds)
    {
        anim.SetBool("isHit", true);

        screenBlood.color = new Color32(255, 0, 0, 49);

        isHit = true;

        yield return new WaitForSeconds(waitForSeconds);

        anim.SetBool("isHit", false);

        screenBlood.color = new Color32(255, 0, 0, 0);

        isHit = false;
    }

    public IEnumerator playerDash(float dashLength, float dashSpeed, float dashReset, int dashDamage)
    {
        moveSpeed = dashSpeed;
        playerCanDash = false;

        //playerHealthController.instance.healthChange(false, true, dashDamage);
        //StartCoroutine(playerHit(dashLength));

        yield return new WaitForSeconds(dashLength);

        moveSpeed = moveSpeedNormal;

        yield return new WaitForSeconds(dashReset);

        playerCanDash = true;
    }
}

// -351, -85 for shotty img
// -351, -74 for backgroundShotty IMG

// -256, -74 for revolver backgroundImg
//-253, -85 for revolverIMG