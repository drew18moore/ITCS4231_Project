using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractables : MonoBehaviour
{
    public KeyCode interactKey;
    public float interactRange = 4f;
    public Camera cam;

    private bool hasKey = false;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactRange) && hit.transform.tag == "ExitDoor")
        {
            Debug.Log("LOOKING AT DOOR");
            if (Input.GetKey(interactKey) && hasKey)
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }

    public void CollectKey()
    {
        hasKey = true;
    }
}
