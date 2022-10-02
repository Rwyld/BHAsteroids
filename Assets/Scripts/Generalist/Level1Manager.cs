using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public GameObject[] enemys;
    public Vector2 bounds;
    public int en_numbers;
    public float timeDelay;
    public float timeReset;
    public float RNG;


    void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(SpawnArea());
        RNG = Random.value * 100f;
        print(RNG);
    }
    

    IEnumerator SpawnArea()
    {
        
        for (int i = 0; i < enemys.Length; i++)
        {
            yield return new WaitForSeconds(5);
            int a = Random.Range(0, enemys.Length);
            GameObject enemy = Instantiate(enemys[a]);
            enemy.transform.position = new Vector2(Random.Range(-bounds.x, bounds.x), Random.Range(-bounds.y, bounds.y));
            en_numbers++;
        }
        
    }

    private void Update()
    {

    }


}
