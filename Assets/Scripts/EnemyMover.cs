using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target;
    [SerializeField] float lookDistance = 10f;



    private void Start()
    {
        StartCoroutine(MoveRoutine());
    }
    
    IEnumerator MoveRoutine()
    {
        WaitForSeconds delay = new WaitForSeconds(0.2f);
    
        while (true)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance <= lookDistance)
            {
                agent.destination = target.position;
            }
            else
            {
                agent.destination = transform.position;
            }
            yield return delay;
        }
    }
}
