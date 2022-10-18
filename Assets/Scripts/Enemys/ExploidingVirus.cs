using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploidingVirus : MonoBehaviour
{
    public EnemyController ec;
    public Transform[] spawn;
    public GameObject en_proyectile;
    public float timeDelay;
    public float timeReset;
    public Collider2D virusCol;

    private void Exploid()
    {
        if (ec.health <= 0)
        {
            virusCol.enabled = false;
            for (int i = 0; i < spawn.Length; i++)
            {
                GameObject proyectile = Instantiate(en_proyectile);
                proyectile.transform.position = spawn[i].transform.position;
                proyectile.transform.rotation = spawn[i].transform.rotation;
            }
        }
    }

    private void Attacking()
    {
        timeDelay -= Time.deltaTime;
        if (timeDelay <= 0)
        {
            for (int i = 0; i < spawn.Length; i++)
            {
                GameObject proyectile = Instantiate(en_proyectile);
                proyectile.transform.position = spawn[i].transform.position;
                proyectile.transform.rotation = spawn[i].transform.rotation;
                Destroy(proyectile, 2.5f);
                timeDelay = timeReset;
            }
                
        }
    }




    private void Update()
    {
        Exploid();
        Attacking();
    }
}
