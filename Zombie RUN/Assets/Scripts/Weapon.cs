using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float raycastRange = 100f;
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot() {
        RaycastHit hit;
        Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, raycastRange);
        Debug.Log("Shoot Something named: " + hit.transform.name);
    }
}
