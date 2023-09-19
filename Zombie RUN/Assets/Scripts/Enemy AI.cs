using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseDistance = 5f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    const string IDLE_ANIMATOR = "idle";
    const string MOVE_ANIMATOR = "move";
    const string ATTACK_ANIMATOR = "attack";


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

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    void EngageTarget()
    {
        if(distanceToTarget >= navMeshAgent.stoppingDistance) {
            GetComponent<Animator>().SetBool(ATTACK_ANIMATOR, false);
            ChaseTarget();
        } 
        
        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
            FaceTarget();
        }
    }

    private void ChaseTarget()
    { 
        GetComponent<Animator>().SetTrigger(MOVE_ANIMATOR);
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool(ATTACK_ANIMATOR, true);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }


    // For Debug
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }
    


}
