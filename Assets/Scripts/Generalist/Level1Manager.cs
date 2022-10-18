using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level1Manager : MonoBehaviour
{
    public BossController bc;
    public GameObject[] enemys;
    public GameObject boss, warningE, victoryMenu;
    public Vector2 bounds;
    public float timeDelay;
    public float timeReset;
    public float RNG;
    public int remainingEn;
    public int minEn, maxEn, en_numbers;
    public bool bosstime = false;
    public Vector2 spawn;
    public int enType;


    void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        RNGnumbers();
        StartCoroutine(SpawnArea());
    }
    private void Update()
    {
        StartCoroutine(BossSpawn());

        if (bc.health <= 0)
        {
            StartCoroutine(Victory());
        }
    }

    private void RNGnumbers()
    {

        RNG = Random.value * 100f;
        en_numbers = Random.Range(minEn, maxEn);
        Score.instance.SetEnemy(en_numbers);
        print(RNG);

        if (RNG <= 1)
        {
            en_numbers = 0;
        }
    } 

    private void Warning()
    {
        GameObject warningEnemy = Instantiate(warningE);
        warningEnemy.transform.position = spawn;
        Destroy(warningEnemy, 1.3f);
    }

    private void EnemyGen()
    {
        GameObject enemy = Instantiate(enemys[enType]);
        enemy.transform.position = spawn;
    }
    private IEnumerator SpawnArea()
    {
        yield return new WaitForSeconds(2);
        if (RNG <= 1)
        {
            boss.SetActive(true);

        }
        else if (RNG >= 1)
        {
            for (int i = 0; i < en_numbers; i++)
            {
                spawn = new Vector2(Random.Range(-bounds.x, bounds.x), Random.Range(-bounds.y, bounds.y));
                enType = Random.Range(0, enemys.Length);
                Warning();
                yield return new WaitForSeconds(1.3f);
                EnemyGen();
            }
        }
    }

    private IEnumerator BossSpawn()
    {
        if (bosstime)
        {
            yield return new WaitForSeconds(5);
            boss.SetActive(true);
            bosstime = false;
        }
    }

    private IEnumerator Victory()
    {
        yield return new WaitForSeconds(2);
        victoryMenu.SetActive(true);
    }
}
