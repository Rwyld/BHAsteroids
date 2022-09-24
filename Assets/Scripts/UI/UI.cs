using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Debug.Log("Alt + f4");
        //Application.Quit();
    }



}
