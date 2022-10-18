using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health = 10f;
    public float speed;
    public float timeFlip = 2f;
    public bool SetActive = true;
    public GameObject drop;
    public int drops;
    public Rigidbody2D rb;
    public float timeDestroy;
    public float timeLiving;
    public Vector2 bounds;
    public AudioSource death;


    private void Awake()
    {
        death.Pause();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Rotate();
    }

    void Update()
    {
        MoveTo();
        OutCamera();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Score.instance.EnemyCount(1);
            death.Play();
            drops = Random.Range(1, 3);
            for (int i = 0; i < drops; i++)
            {
                Instantiate(drop, transform.position, Quaternion.identity);
            }
            Destroy(gameObject,timeDestroy);
        }
    }

    private void OutCamera()
    {
        Vector2 boundsX = bounds * 1.5f;
        if(transform.position.x < -boundsX.x || transform.position.y < -boundsX.y || transform.position.x > boundsX.x || transform.position.y > boundsX.y)
        {
            Destroy(this.gameObject);
        }
    }
    
    private void MoveTo()
    {
        Look();
        float dir = Vector2.Distance(GameManager.instance.player.transform.position, transform.position);
        if (dir > 15f)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.player.transform.position, speed * Time.deltaTime);

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.player.transform.position, 0.5f * Time.deltaTime);
            
        }
    }

    private void Look()
    {
        Quaternion rotation = Quaternion.LookRotation(GameManager.instance.player.transform.position - transform.position, transform.TransformDirection(Vector3.up));   
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

    }
    private void Rotate()
    {
        if (transform.position.x > GameManager.instance.player.transform.position.x)
        {
            transform.Rotate(0f, 0f, 180f);
        }
    }
}
