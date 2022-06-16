using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float enemyHealth;

    public GameObject healthBarUI;
    public Slider slider;

    private void Start()
    {
        enemyHealth = maxHealth;
        slider.value = CalculateHealth();
    }

    private void Update()
    {
        slider.value = CalculateHealth();

        if (enemyHealth < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
    }

    public void DamageEnemy(int amount)
    {
        enemyHealth -= amount;
        if (enemyHealth <= 0) { Destroy(gameObject); }
    }

    float CalculateHealth()
    {
        return enemyHealth / maxHealth;
    }
}
