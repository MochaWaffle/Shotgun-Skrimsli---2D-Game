using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneLoader : MonoBehaviour
{
    public static sceneLoader instance;

    void Awake()
    {
        instance = this;
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        /*if (GameManager.instance.pauseScreenOn == true)
        {
            
        }*/

        GameManager.instance.pauseScreenChange(false);
    }
}
