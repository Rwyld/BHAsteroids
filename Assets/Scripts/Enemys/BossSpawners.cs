using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawners : MonoBehaviour
{
    public float speed;
    public float flipTime;
    public float flipTimeReset;
    public float rotationSpeed;
    public bool Moving;
    public bool Rotating;
    public bool Fliping;
    public bool Lasers;
    public float firstMov = 2f;
    public float secondMov = 35f;

    private void Start()
    {
    }

    private void Move()
    {
        flipTime -= Time.deltaTime;
        //transform.Translate(transform.position.x * speed, 0f, 0f);



        if (flipTime <= 0 && Fliping)
        {
            speed *= -1;
            flipTime = flipTimeReset;
        }
    }

    private void Rotation()
    {
        transform.Rotate(0, 0, 90f * rotationSpeed * Time.deltaTime);
    }

    private void LasersMov()
    {
        firstMov -= Time.deltaTime;
        secondMov -= Time.deltaTime;
        if (firstMov <= 0)
        {
            transform.Translate(new Vector2(1 * speed * Time.deltaTime, 0f));
        }
        if (secondMov <= 0)
        {
            transform.Translate(new Vector2(1 * -speed * Time.deltaTime, 0f));
        }
        
    }


    private void Update()
    {
        if (Moving)
        {
            Move();
        }
        if (Rotating)
        {
            Rotation();
        }
        if (Lasers)
        {
            LasersMov();
        }
    }

}
