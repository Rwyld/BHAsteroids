using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public Camera camera_;
    public GameObject pl_proyectile;
    public Transform shootPoint;
    public float timeDestroy = 2.5f;
    public float timeDelay = 1f;
    public float timeReset = 0.2f;


    private void FixedUpdate()
    {
        Timer();
        MouseRotation();
        Shoot();
    }

    private void MouseRotation()
    {
        float angle = GetAngleTowardsMouse();
        
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    private float GetAngleTowardsMouse()
    {
        Vector3 mouseWorldPosition = camera_.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDirection = mouseWorldPosition - transform.position;
        mouseDirection.z = 0;
        float angle = (Vector3.SignedAngle(Vector3.right, mouseDirection, Vector3.forward) + 360) % 360;

        return angle;
    }

    private void Shoot()
    {
        if (Input.GetMouseButton(0) && timeDelay <= 0)
        {
            GameObject playerProyectile = Instantiate(pl_proyectile);
            playerProyectile.transform.position = shootPoint.position;
            playerProyectile.transform.rotation = shootPoint.rotation;
            Destroy(playerProyectile, timeDestroy);
            timeDelay = timeReset;
        }
    }

    private void Timer()
    {
        timeDelay -= Time.deltaTime;
    }
}

