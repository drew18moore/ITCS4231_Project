using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractables : MonoBehaviour
{
    public KeyCode interactKey;
    public float interactRange = 4f;
    public Camera cam;

    private GameObject chest;
    public GameObject Key;
    public GameObject KeyImg;

    public bool hasKey = false;

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

                    if (chest.GetComponent<KeyHandler>().haskey && !hasKey)
                    {
                        Instantiate(Key, chest.transform.position + chest.transform.up * 1f, chest.transform.rotation);
                    }
                }
            }
        }

    }

    public void CollectKey()
    {
        hasKey = true;
        KeyImg.SetActive(true);
    }

    IEnumerator stopAnimation(Animator anim)
    {
        yield return new WaitForSeconds(3f);
        anim.speed = 0;
    }
}
