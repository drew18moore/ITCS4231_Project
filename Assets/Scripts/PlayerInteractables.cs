using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractables : MonoBehaviour
{
    public KeyCode interactKey;
    public float interactRange = 4f;
    public Camera cam;

    public GameObject chest;

    private bool hasKey = false;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactRange))
        {
            if (hit.transform.tag == "ExitDoor")
            {
                Debug.Log("LOOKING AT DOOR");
                if (Input.GetKey(interactKey) && hasKey)
                {
                    Destroy(hit.transform.gameObject);
                }
            }
            else if (hit.transform.tag == "Chest")
            {
                Debug.Log("LOOKING AT CHEST");
                if (Input.GetKey(interactKey))
                {
                    chest = hit.transform.gameObject;
                    Debug.Log("OPEN CHEST");
                    Animator anim = chest.GetComponent<Animator>();
                    anim.Play("Open");
                    StartCoroutine(stopAnimation(anim));
                }
            }
        }

    }

    public void CollectKey()
    {
        hasKey = true;
    }

    IEnumerator stopAnimation(Animator anim)
    {
        yield return new WaitForSeconds(3f);
        anim.speed = 0;
    }
}
