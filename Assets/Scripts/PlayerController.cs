using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField, Range(0,100)] private float speed;
    public float maxHealth = 100;
    public float curHealth;

    private float movx;
    private float movy;
    private float limitex = 38;
    private float limitey = 21;

    public void PlayerTakeDamage(float damage)
    {
        curHealth--;
        if (curHealth <= 0)
        {
            //Animacion
            //TimeDelay
            //UI Game Over 
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        curHealth = maxHealth;
    }

    void FixedUpdate()
    {
        movx = Input.GetAxis("Horizontal");
        movy = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(movx * speed, movy * speed, 0);


        if (transform.position.x < -limitex)
        {
            transform.position = new Vector3(-limitex, transform.position.y, 0);
        }
        if (transform.position.x > limitex)
        {
            transform.position = new Vector3(limitex, transform.position.y, 0);
        }
        if (transform.position.y < -limitey)
        {
            transform.position = new Vector3(transform.position.x, -limitey, 0);
        }
        if (transform.position.y > limitey)
        {
            transform.position = new Vector3(transform.position.x, limitey, 0);
        }
    }
}
