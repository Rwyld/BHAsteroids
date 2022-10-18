using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public Score sc;
    public GameObject exit, finalScore;
    public string sceneName;
    public Animator animator;


    private void Start()
    {
        StartCoroutine(Final());


    }

    private IEnumerator Final()
    {
        yield return new WaitForSeconds(1);
        finalScore.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        exit.SetActive(true);
    }

    public void ExitToMain()
    {
        StartCoroutine(NextScene());
    }

    public IEnumerator NextScene()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }

}
