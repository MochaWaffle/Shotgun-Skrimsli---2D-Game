using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject pauseScreen;
    public bool pauseScreenOn = false;
    public List<GameObject> enemies = new List<GameObject>();

    public string nextScene;

    public GameObject explosionImage;

    public Image explosionImageColor;
    private void Awake()
    {
        pauseScreenChange(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        print(enemies.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseScreenOn == false)
            {
                pauseScreenChange(true);
            } else
            {
                pauseScreenChange(false);
            }
        }
    }

    public void pauseScreenChange(bool screenOn)
    {
        pauseScreen.SetActive(screenOn);

        if(screenOn == true)
        {
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 1f;
        }
        pauseScreenOn = screenOn;
    }

    public void deathPoolSpawn(ParticleSystem enemyBlood, Vector3 position)
    {
        StartCoroutine(deathBlood(enemyBlood, position));
    }
    public IEnumerator deathBlood(ParticleSystem enemyBlood, Vector3 position)
    {
        GameObject enemyBloodTemp = Instantiate(enemyBlood.gameObject, position, Quaternion.identity);

        yield return new WaitForSeconds(3f);

        Destroy(enemyBloodTemp);
    }

    public void deathPosionPoolActivate()
    {
        StartCoroutine(deathPoisionPool());
    }
    public IEnumerator deathPoisionPool()
    {
        //greenSlimePool.instance.isPoisioned = true;
        for (int i = 0; i < 5; i++)
        {
            this.gameObject.GetComponent<enemyController>().Attack(1, .5f);
            yield return new WaitForSeconds(1f);

        }
        //greenSlimePool.instance.isPoisioned = false;
    }
}
