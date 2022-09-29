using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string sceneName;


    public void Setup()
    {
        gameObject.SetActive(true);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitToMain()
    {
        SceneManager.LoadScene(0);
    }
}
