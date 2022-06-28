using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<playerHealth>().damagePlayer(15);   
        }
        Destroy(gameObject);
        
    }
}
