using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilePlayerController : MonoBehaviour
{
    public float damage = 1;
    public float speed = 10f;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.right * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController enemy = collision.GetComponent<EnemyController>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        

        
    }
}
