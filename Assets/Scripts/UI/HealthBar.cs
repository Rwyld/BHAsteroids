using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerController pc;
    public Image healthbar;

    void Update()
    {
        healthbar.fillAmount = (pc.curHealth/pc.maxHealth);
    }
}
