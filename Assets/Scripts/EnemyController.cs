using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health = 10f;
    public float speed = 30f;
    public float timeFlip = 2f;
    public bool SetActive = true;
    public GameObject en_proyectile;
    public Rigidbody2D rb;
    public Transform spawn;
    public Transform py_spawn;
    public bool isVertical;


    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        if (isVertical == true)
        {
            rb.velocity = Vector2.up * speed * Time.deltaTime;
        }

        if (isVertical == false)
        {
            rb.velocity = Vector2.right * speed * Time.deltaTime;
        }
    }
}
