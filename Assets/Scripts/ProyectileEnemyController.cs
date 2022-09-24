using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileEnemyController : MonoBehaviour
{
    public float damage = 20;
    public float speed = 10f;
    public float timeDestroy = 2.5f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, timeDestroy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            player.PlayerTakeDamage(damage);
        }
    }
}
