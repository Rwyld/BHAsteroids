using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    public TextMeshProUGUI text;
    public int score;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ScorePoints(int points)
    {
        score += points;
        text.text = score.ToString();
    }

}
