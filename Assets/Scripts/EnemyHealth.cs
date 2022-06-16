using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;

    public void DamageEnemy(int amount)
    {
        enemyHealth -= amount;
        if (enemyHealth <= 0) { Destroy(gameObject); }
    }
}
