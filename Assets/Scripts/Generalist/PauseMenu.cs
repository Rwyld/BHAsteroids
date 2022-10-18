using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string sceneName;
    public GameObject pauseMenu;

    public void Continue()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneName);
    }
}
