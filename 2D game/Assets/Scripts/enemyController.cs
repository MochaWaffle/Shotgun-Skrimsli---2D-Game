using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public static enemyController instance;
    public int health;
    public int damage;
    public float waitHit;
    public Animator enemyAnim;
    public Animator screenBloodAnim;
    private bool hit = false;
    public ParticleSystem enemyBlood;
    public GameObject enemyPlaceHolder;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        screenBloodAnim = GameObject.Find("screenBlood").GetComponent<Animator>();
        //GameManager.instance.enemies.Add(this.gameObject as GameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int amount, float waitForSeconds)
    {
        health -= amount;
        StartCoroutine(enemyHit(waitForSeconds));

        if (health <= 0)
        {
            //StartCoroutine(testGameEnd());
            GameManager.instance.deathPoolSpawn(enemyBlood, this.gameObject.transform.position);
            //Destroy(this.gameObject);
            Destroy(enemyPlaceHolder);
            GameManager.instance.enemies.Remove(this.gameObject as GameObject);
            
            //enemyBlood.Play();
            if(GameManager.instance.enemies.Count == 0)
            {
                sceneLoader.instance.LoadScene(GameManager.instance.nextScene);
            }
        }
    }

    public void Attack(int amount, float waitForSeconds)
    {
        if (playerHealthController.instance.healthNumber > 0)
        {
            
            playerHealthController.instance.healthChange(false, true, amount);
            
            StartCoroutine(playerController.instance.playerHit(waitForSeconds));
            
            StartCoroutine(waitBeforeHit(waitHit));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player" && hit == false)
        {
            Attack(damage, .35f);
        } //else
        //{
          //  playerController.instance.isHit = false;
        //}
    }

    IEnumerator waitBeforeHit(float wait)
    {
        hit = true;

        yield return new WaitForSeconds(wait);

        hit = false;
    }
    /*
    IEnumerator animationHit()
    {
        anim.SetBool("isHit", true);
        yield return new WaitForSeconds(.35f);
        anim.SetBool("isHit", false);
    }
    */
    public IEnumerator enemyHit(float waitForSeconds)
    {
        enemyAnim.SetBool("isHit", true);

        yield return new WaitForSeconds(waitForSeconds);

        enemyAnim.SetBool("isHit", false);
    }

    public IEnumerator testGameEnd()
    {
        cineMachineShake.instance.ShakeCamera(10, 3f);
        GameManager.instance.explosionImage.SetActive(true);
        yield return new WaitForSeconds(1f);
        GameManager.instance.explosionImageColor.color = new Color32(255, 204, 0, 156);
        yield return new WaitForSeconds(.5f);
        GameManager.instance.explosionImageColor.color = new Color32(255, 149, 0, 156);
        yield return new WaitForSeconds(1f);
        sceneLoader.instance.QuitGame();
    }

}
