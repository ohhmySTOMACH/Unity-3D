using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


public class Oscillator : MonoBehaviour
{
    UnityEngine.Vector3 startingPosition;
    [SerializeField] UnityEngine.Vector3 movementVector;
    [SerializeField][Range(0,1)]float movementFactor;
    [SerializeField] float period = 2f;

    void Start()
    {
        startingPosition = transform.position;
        Debug.Log(startingPosition);
    }

    void Update()
    {
        MoveBackAndForth();
    }

    private void MoveBackAndForth()
    {
        if (period < Mathf.Epsilon) {return;}
        const float tau = 2 * Mathf.PI;
        float cycles = Time.time / period;
        float rawSinWave = Mathf.Sin(cycles * tau);
        movementFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1
        UnityEngine.Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
