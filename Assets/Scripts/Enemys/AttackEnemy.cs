using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public GameObject en_proyectile;
    public float targetAttack;
    public float timeDelay;
    public float timeReset;
    public float timeDestroy;
    public Transform[] py_spawn;

    private void TargetAttack()
    {
        targetAttack = Vector2.Distance(GameManager.instance.player.transform.position, transform.position);

        if (targetAttack <= 50)
        {
            timeDelay -= Time.deltaTime;

            if (timeDelay <= 0)
            {
               for (int i = 0; i < py_spawn.Length; i++)
                {
                    GameObject enemyProyectile = Instantiate(en_proyectile);
                    enemyProyectile.transform.position = py_spawn[i].position;
                    enemyProyectile.transform.rotation = py_spawn[i].rotation;
                    Destroy(enemyProyectile, timeDestroy);
                    timeDelay = timeReset;
                }
                
            }
        }
    }

    void Update()
    {
        TargetAttack();
    }
}
