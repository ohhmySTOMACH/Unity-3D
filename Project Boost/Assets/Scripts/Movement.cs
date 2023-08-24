using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody movementRigidbody;
    [SerializeField] float mainThrust = 150f;
    [SerializeField] float rotationThrust = 100f;

    // Start is called before the first frame update
    void Start()
    {
        movementRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // (0,1,0)
            movementRigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            Debug.Log("Pressed SPACE - Thrusting");
        }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            // Freeze rotation so we can manually rotate
            movementRigidbody.freezeRotation = true;

            // Or (0,0,zAngle)
            transform.Rotate(Vector3.forward * rotationThrust * Time.deltaTime);

            // Unfreeze rotation so that physics system can take over
            movementRigidbody.freezeRotation = false; 
        }
        else if(Input.GetKey(KeyCode.D))
        {
            movementRigidbody.freezeRotation = true;
            transform.Rotate(Vector3.back * rotationThrust * Time.deltaTime);
            movementRigidbody.freezeRotation = false;
        }
    }
}
