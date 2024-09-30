using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target;
    [SerializeField] float lookDistance = 8f;
    [SerializeField] Animator animator;

    private bool playerInRange = false;


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
                animator.SetBool("isWalking", true);
            }
            else
            {
                agent.destination = transform.position;
                animator.SetBool("isWalking", false);
                animator.SetBool("isIdle", true); 
            }
            yield return delay;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", false);
            animator.SetTrigger("attack");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false; 
            animator.SetBool("isIdle", true); 
        }
    }
}
