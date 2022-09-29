using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public GameObject enemyManager;
    public Transform startPosition;
    public GameObject gameOver;


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
        
    }

    public void RestartGame()
    {
        StartCoroutine(RestartGameTime());
    }

    public IEnumerator RestartGameTime()
    {
        yield return new WaitForSeconds(1);
        gameOver.SetActive(true);
    }
}
