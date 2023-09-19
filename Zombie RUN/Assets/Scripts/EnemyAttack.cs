using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float enemyDamage = 40f;

    void Start () 
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent() 
    {
        if (target == null) {return;}
        target.TakeDamage(enemyDamage);
    }

    public void OnDamageTaken()
    {
        Debug.Log("Also Take Damage");
    }
}
