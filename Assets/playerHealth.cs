using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    [SerializeField] private float playerHP = 100f;

    private void Update()
    {
        Debug.Log(playerHP);
        if (playerHP <= 0f)
        {
            Debug.Log("PLAYER DEAD");
        }
    }

    public void damagePlayer(float amount)
    {
        playerHP -= amount;
    }
}
