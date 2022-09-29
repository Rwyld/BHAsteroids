using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    public int numbers;
    public GameObject enemys;

    public float timeToSpawn = 0.5f;
    private void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    private IEnumerator SpawnTimer()
    {
        for (int i = 0; i < numbers; i++)
        {
            yield return new WaitForSeconds(timeToSpawn);
            Instantiate(enemys, transform.position, transform.rotation);

        }
        Destroy(gameObject);
    }
}
