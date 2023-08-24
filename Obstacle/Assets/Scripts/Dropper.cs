using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    MeshRenderer dropperRederer;
    Rigidbody dropperRigidbody;
    [SerializeField]float timeToWait = 2f;
    // Start is called before the first frame update
    void Start()
    {
        dropperRederer = GetComponent<MeshRenderer>();
        dropperRigidbody = GetComponent<Rigidbody>();

        dropperRederer.enabled = false;
        dropperRigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeToWait)
        {
            dropperRederer.enabled = true;
            dropperRigidbody.useGravity = true;
        }
    }
}
