using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseDistance = 5f;

    NavMeshAgent navMeshAgent;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked) {
            EngageTarget();
        } else if(distanceToTarget <= chaseDistance) {
            isProvoked = true;
        }
    }

    void EngageTarget()
    {
        if(distanceToTarget > navMeshAgent.stoppingDistance) {
            ChaseTarget();
        } else {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
        Debug.Log("Distance: " + distanceToTarget);
    }

    private void AttackTarget()
    {
        Debug.Log("Attacking Target" + target.name);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }
    


}
