using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileEnemyController : MonoBehaviour
{
    public float damage = 20;
    public float speed = 10f;
    public float timeDestroy = 2.5f;
    public Rigidbody2D rb;
    public PlayerController pc;

    void Start()
    {
        Destroy(gameObject, timeDestroy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.GetComponent<PlayerController>();

        if (collision.gameObject.tag == "Player")
        {
            pc.PlayerTakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.right * speed * Time.fixedDeltaTime);
    }
}
