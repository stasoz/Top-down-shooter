using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    Image healthBar;
    float maxHealth = 50f;
    public static float health;

    private void Start()
    {
        healthBar = GetComponent<Image>();
        health = maxHealth;
    }
    private void Update()
    {
        healthBar.fillAmount = health / maxHealth;
    }
}
