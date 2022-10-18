using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    public float damage = 10f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
        pc.PlayerTakeDamage(damage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
