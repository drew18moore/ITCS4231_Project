using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceKeyIntoRandChest : MonoBehaviour
{
    List<Transform> allChests = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            allChests.Add(child);
        }

        int rand = Random.Range(0, transform.childCount);
        allChests[rand].GetComponent<KeyHandler>().haskey = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
