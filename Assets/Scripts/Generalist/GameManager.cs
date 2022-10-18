using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public Transform startPosition;
    public GameObject gameOver;
    public GameObject pauseMenu;
    public bool pause;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }


    void Start()
    {
        player.transform.position = startPosition.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            Time.timeScale = pause ? 0 : 1;

            if (pause)
            {
                pauseMenu.SetActive(true);
            }
            else if (!pause)
            {
                pauseMenu.SetActive(false);
            }
        }
    }

    public void RestartGame()
    {
        StartCoroutine(RestartGameTime());
    }

    public IEnumerator RestartGameTime()
    {
        player.SetActive(false);
        yield return new WaitForSeconds(1);
        gameOver.SetActive(true);
    }

}
