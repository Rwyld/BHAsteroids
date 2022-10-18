using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Animator animator;
    public string sceneName;



    public void PlayGame()
    {
        StartCoroutine(NextScene());
    }
    public void QuitGame()
    {
        Debug.Log("Alt + f4");
        //Application.Quit();
    }

    public IEnumerator NextScene()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }

}
