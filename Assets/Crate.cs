using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public float hits = 2f;

    public void DamageCrate()
    {
        hits--;
        if (hits <= 0) { Destroy(gameObject); }
    }
}
