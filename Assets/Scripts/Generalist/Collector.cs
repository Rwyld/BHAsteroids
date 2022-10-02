using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public int points = 1;
    //public GameObject player;
    public float speed = 20f;

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        StartCoroutine(MoveTo());
    }

    public void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.player.transform.position, speed * Time.deltaTime);
        speed *= 1.05f;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Score.instance.ScorePoints(points);
            Destroy(gameObject);

        }

    }

    public IEnumerator MoveTo()
    {
        yield return new WaitForSeconds(1);
        Move();
        
    }
}
