using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerHealthController : MonoBehaviour
{
    public static playerHealthController instance;

    public Text healthText;
    public int healthNumber;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        healthNumber = int.Parse(healthText.text);
    }

    // Update is called once per frame
    void Update()
    {
        //healthNumber = int.Parse(healthText.text);
        if (healthNumber == 0)
        {
            sceneLoader.instance.LoadScene("lose");
            print(healthNumber);
        }
    }

    public void healthChange(bool add, bool minus, int number)
    {
        if(add == true)
        {
            if (healthNumber <= 50)
            {
                healthNumber += number;

                if(healthNumber > 60)
                {
                    healthNumber = 50;
                }
            }
        }
        if(minus == true)
        {
            if (healthNumber > 0)
            {
                healthNumber -= number;

                if(healthNumber < 0)
                {
                    healthNumber = 0;

                    
                }
            }
        }
        healthText.text = healthNumber.ToString();
    }
}
