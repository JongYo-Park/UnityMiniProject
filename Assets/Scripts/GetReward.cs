using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetReward : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target;
    [SerializeField] Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reward"))
        {
            StartCoroutine(HandleReward());
        }
    }
    private IEnumerator HandleReward()
    {
        animator.SetBool("isWalking", false);

        yield return new WaitForSeconds(0.2f);

        yield return PlayJumpAnimationTwice();
    }

    private IEnumerator PlayJumpAnimationTwice()
    {
        animator.SetTrigger("Jump");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length); 

        animator.SetTrigger("Jump");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
    }
    private void Start()
    {
        StartCoroutine(MoveRoutine());
    }
    
    IEnumerator MoveRoutine()
    {
        WaitForSeconds delay = new WaitForSeconds(0.5f);
    
        while (true)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance > 0.5f)
            {
                agent.SetDestination(target.position);
                if (agent.velocity.magnitude > 0.1f)
                {
                    animator.SetBool("isWalking", true);
                }
                else
                {
                    animator.SetBool("isWalking", false);
                }
            }
            else
            {
                agent.SetDestination(transform.position);
                animator.SetBool("isWalking", false);
            }
            yield return delay;
        }
    }
}
