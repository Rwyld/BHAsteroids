using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public BossController bc;
    public GameObject en_proyectile;
    public float targetAttack;
    public float CD1, CD2, CD4;
    public float CDR1, CDR2, CDR4;
    public float timeDestroy;
    public Transform[] Movesetone;
    public Transform[] Movesettwo;
    public GameObject[] Movesetthree;
    public Transform[] Movesetfour;
    public bool MoveThree = true;
    public LineRenderer[] Laser;
    public GameObject LaserR, LaserL, FirstSpawner, SecondSpawner;



    private void Start()
    {
        Laser[0].enabled = false;
        Laser[1].enabled = false;
        FirstSpawner.SetActive(false);
        SecondSpawner.SetActive(false);
        

        
    }
    private void MoveSetOne()
    {
        if (CD1 <= 0)
        {
            for (int i = 0; i < Movesetone.Length; i++)
            {
                GameObject enemyProyectile = Instantiate(en_proyectile);
                enemyProyectile.transform.position = Movesetone[i].position;
                enemyProyectile.transform.rotation = Movesetone[i].rotation;
                Destroy(enemyProyectile, timeDestroy);
                CD1 = CDR1;
            }
        }
        

    }
    private void MoveSetTwo()
    {
        if (CD2 <= 0)
        {
            for (int i = 0; i < Movesettwo.Length; i++)
            {
            
                //yield return new WaitForSeconds(0.1f);
                GameObject enemyProyectile = Instantiate(en_proyectile);
                enemyProyectile.transform.position = Movesettwo[i].position;
                enemyProyectile.transform.rotation = Movesettwo[i].rotation;
                Destroy(enemyProyectile, timeDestroy);
                
            }
            CD2 = CDR2;

        }
    }

    private void MoveSetThree()
    {
        for (int i = 0; i < Movesetthree.Length; i++)
        {
            Movesetthree[i].SetActive(true);
        }

    }

    private IEnumerator MoveSetFour()
    {

        LaserR.SetActive(true);
        LaserL.SetActive(true);
        yield return new WaitForSeconds(1f);
        Laser[0].enabled = true;
        Laser[1].enabled = true;

    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(2);
        MoveSetOne();
        yield return new WaitForSeconds(2);
        //StartCoroutine(MoveSetTwo());
        yield return new WaitForSeconds(2);
        MoveSetThree();
        yield return new WaitForSeconds(2);
        MoveSetFour();

    }

    private void Timers()
    {
        CD1 -= Time.deltaTime;
        CD2 -= Time.deltaTime;
        CD4 -= Time.deltaTime;

    }

    void Update()
    {
        Timers();
        if (bc.health >= 200 && bc.health <= 300)
        {
            FirstSpawner.SetActive(true);
            MoveSetOne();
        }
        else if (bc.health >= 150 && bc.health <= 200)
        {
            FirstSpawner.SetActive(false);
            SecondSpawner.SetActive(true);
            MoveSetTwo();
        }
        else if (bc.health >= 100 && bc.health <= 150)
        {
            SecondSpawner.SetActive(false);
            MoveSetThree();
        }
        else if (bc.health >= 50 && bc.health <= 100)
        {
            StartCoroutine(MoveSetFour());
        }
        else if (bc.health > 0 && bc.health <= 50)
        {
            FirstSpawner.SetActive(false);
            SecondSpawner.SetActive(true);
            MoveSetOne();
            MoveSetTwo();
        }

        else if (bc.health <= 0)
        {
            FirstSpawner.SetActive(false);
            SecondSpawner.SetActive(false);

            for (int i = 0; i < Movesetthree.Length; i++)
            {
                Movesetthree[i].SetActive(false);
            }

            LaserR.SetActive(false);
            LaserL.SetActive(false);
            Laser[0].enabled = false;
            Laser[1].enabled = false;

        }
    }

}
