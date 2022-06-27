using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitTrigger : MonoBehaviour
{
    public float healAmount = 25f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && other.GetComponent<playerHealth>().playerHP < other.GetComponent<playerHealth>().maxPlayerHP)
        {
            other.GetComponent<playerHealth>().healPlayer(healAmount);
            Destroy(gameObject);
        }
    }
}
