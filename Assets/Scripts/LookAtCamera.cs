using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    //public Camera cam = GameObject.FindGameObjectsWithTag("MainCamera")[0];
    // Update is called once per frame
    public Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        transform.LookAt(transform.position + cam.transform.rotation * Vector3.back, cam.transform.rotation * Vector3.up);
    }
}
