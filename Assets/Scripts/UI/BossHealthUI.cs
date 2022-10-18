using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthUI : MonoBehaviour
{
    public BossController bc;
    public Image healthbar;
    public Animator animator;
    public GameObject UI;

    private void Start()
    {
        UI.SetActive(true);
        animator.SetBool("isBossFight", true);
    }

    void Update()
    {
        healthbar.fillAmount = (bc.health / bc.maxHealth);
    }
}
