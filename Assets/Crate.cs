using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public float hits = 2f;
    public float chanceToDropMedkit = 0.5f;
    public GameObject medkitPrefab;

    public void DamageCrate()
    {
        hits--;
        if (hits <= 0) 
        {
            if (Random.value > 1 - chanceToDropMedkit) { Instantiate(medkitPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity); }
            Destroy(gameObject);
        }
    }
}
