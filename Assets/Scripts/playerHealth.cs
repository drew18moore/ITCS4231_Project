using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float maxPlayerHP = 100f;
    private float playerHP;

    public Slider slider;

    private void Start()
    {
        playerHP = maxPlayerHP;
        slider.value = CalculateHealth();
    }

    private void Update()
    {
        slider.value = CalculateHealth();
        // Debug.Log(playerHP);

        if (playerHP <= 0f)
        {
            Debug.Log("PLAYER DEAD");
        }
    }

    public void damagePlayer(float amount)
    {
        playerHP -= amount;
    }

    float CalculateHealth()
    {
        return playerHP / maxPlayerHP;
    }
}
