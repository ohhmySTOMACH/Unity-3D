using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHitPoints = 100f;
    public void TakeDamage(float damageAmount) {
        playerHitPoints -= damageAmount;
        if (playerHitPoints <= Mathf.Epsilon) {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
