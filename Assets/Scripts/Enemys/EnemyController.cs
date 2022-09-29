using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health = 10f;
    public float speed;
    public float timeFlip = 2f;
    public bool SetActive = true;
    public GameObject en_proyectile;
    public GameObject drop;
    public int drops;
    public Rigidbody2D rb;
    public Transform spawn;
    public Transform py_spawn;
    public GameObject target;
    public bool isVer;
    public bool isHor;
    public bool rightLeft;
    public bool upDown;
    public float targetAttack;
    public float timeDelay;
    public float timeReset;
    public float timeDestroy;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, 8f);
    }

    void Update()
    {
        TargetAttack();
        Move();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            drops = Random.Range(1, 3);
            for (int i = 0; i < drops; i++)
            {
                Instantiate(drop, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

    private void Move()
    {
        if (isVer == true && upDown == true)
        {
            transform.position += new Vector3(0f, -1f * speed * Time.fixedDeltaTime, 0f);
        }
        if (isVer == true && upDown == false)
        {
            transform.position += new Vector3(0f, 1f * speed * Time.fixedDeltaTime, 0f);
        }
        if (isHor == true && rightLeft == true)
        {
            transform.position += new Vector3(-1f * speed * Time.fixedDeltaTime, 0f, 0f);
        }

        if (isHor == true && rightLeft == false)
        {
            transform.position += new Vector3(1f * speed * Time.fixedDeltaTime, 0f, 0f);
        }
    }

    private void TargetAttack()
    {
        targetAttack = Vector2.Distance(target.transform.position, transform.position);
        
        if (targetAttack <= 50)
        {
            timeDelay -= Time.deltaTime;

            if (timeDelay <= 0)
            {
                GameObject enemyProyectile = Instantiate(en_proyectile);
                enemyProyectile.transform.position = py_spawn.position;
                enemyProyectile.transform.rotation = py_spawn.rotation;
                Destroy(enemyProyectile, timeDestroy);
                timeDelay = timeReset;
            }
        }
    }
}
