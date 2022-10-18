using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float speed;
    public float timeFlip = 2f;
    public bool SetActive = true;
    public GameObject drop;
    public int drops;
    public Rigidbody2D rb;
    public float timeDestroy;
    public float timeLiving;
    public Vector2 bounds;
    public Collider2D bossCol;
    public Animator animator;




    void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        
    }

    void Update()
    {
        
        MoveTo();
        //OutCamera();

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            bossCol.enabled = false;
            animator.SetTrigger("Death");
            drops = Random.Range(1, 3);
            for (int i = 0; i < drops; i++)
            {
                Instantiate(drop, transform.position, Quaternion.identity);
            }
            Destroy(gameObject, timeDestroy);
        }
    }

    private void OutCamera()
    {
        Vector2 boundsX = bounds * 2f;
        if (transform.position.x < -boundsX.x || transform.position.y < -boundsX.y || transform.position.x > boundsX.x || transform.position.y > boundsX.y)
        {
            Destroy(this.gameObject);
        }
    }

    private void MoveTo()
    {

        float dir = Vector2.Distance(GameManager.instance.player.transform.position, transform.position);
        if (transform.position.y > bounds.y)
        {
            //transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.player.transform.position, speed * Time.deltaTime);
            transform.Translate(0f, -5f * Time.deltaTime, 0f);

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.player.transform.position, 0 * Time.deltaTime);

        }
    }

}
