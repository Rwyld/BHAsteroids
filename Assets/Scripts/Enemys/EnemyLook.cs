using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook : MonoBehaviour
{

    void Update()
    {   
        Look();
    }

    private void Look()
    {
        Quaternion rotation = Quaternion.LookRotation(GameManager.instance.player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }
}
