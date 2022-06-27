using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public float maxPlayerHP = 100f;
    public float playerHP;

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
            SceneManager.LoadScene(3);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void damagePlayer(float amount)
    {
        playerHP -= amount;
    }

    public void healPlayer(float amount)
    {
        playerHP += amount;
    }

    float CalculateHealth()
    {
        return playerHP / maxPlayerHP;
    }
}
