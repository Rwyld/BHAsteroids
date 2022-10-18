using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public Level1Manager lm;
    public TextMeshProUGUI scoreT, enemyT, finalScore;
    public GameObject warning;
    public int score;
    public int enemy;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public void SetEnemy(int numbersEnemy)
    {
        enemy = numbersEnemy;
        enemyT.text = enemy.ToString() + " Remaining Enemys";
    }

    public void ScorePoints(int points)
    {
        score += points;
        scoreT.text = score.ToString();
        finalScore.text = "You Collect " + score.ToString();
    }

    public void EnemyCount(int enemycounts)
    {
        enemy -= enemycounts;
        enemyT.text = enemy.ToString() + " Remaining Enemys";

        if (enemy <= 0)
        {
            lm.bosstime = true;
            enemyT.text = " ";
            StartCoroutine(WarningAd());
        }
    }

    public IEnumerator WarningAd()
    {
        yield return new WaitForSeconds(0.5f);
        warning.SetActive(true);
        yield return new WaitForSeconds(2);
        warning.SetActive(false);
    }

}


