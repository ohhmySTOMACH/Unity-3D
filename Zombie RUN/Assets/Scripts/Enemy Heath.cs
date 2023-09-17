using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHeath : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    // Update is called once per frame
    public void TakeDamage(float damageAmount){
        hitPoints -= damageAmount;
        Debug.Log("Remaining health: " + hitPoints);
        if (hitPoints <= Mathf.Epsilon) {
            Destroy(gameObject);
        }
    }
}
