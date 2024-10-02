using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] float dashPower = 2f;
    [SerializeField] float dashTime = 0.3f;
    [SerializeField] float dashCooltime = 2f;
    [SerializeField] Animator animator;

    private bool isDashing = false;
    private bool isAttacking = false;
    private float walkSpeed;

    private void Start()
    {
        walkSpeed = moveSpeed;
    }
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(x, 0, z).normalized;

        if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            animator.SetTrigger("Dash");
            StartCoroutine(Dash(moveDir));
        }
        else if (Input.GetKeyDown(KeyCode.A) && !isAttacking)
        {
            animator.SetTrigger("Punch");
        }
        else if (Input.GetKeyDown(KeyCode.S) && !isAttacking)
        {
            animator.SetTrigger("Throwing");
        }
        else if (moveDir.magnitude > 0 && !isDashing && !isAttacking)
        {
            animator.SetBool("IsWalking", true);
            transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
            Quaternion lookRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, rotateSpeed);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
    private IEnumerator Dash(Vector3 direction)
    {
        isDashing = true;
        float walkSpeed = moveSpeed;
        moveSpeed *= dashPower;

        float dashTimeElapsed = 0f;
        while (dashTimeElapsed < dashTime)
        {
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
            dashTimeElapsed += Time.deltaTime;
            yield return null;
        }

        moveSpeed = walkSpeed;
        
        isDashing = false;

        UpdateState();
        yield return new WaitForSeconds(dashCooltime);
    }

    private IEnumerator AttackRoutine()
    {
        isAttacking = true; 
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
        UpdateState();
    }

    private void UpdateState()
    {
        if (!isDashing && !isAttacking)
        {
            animator.SetBool("IsWalking", Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0);
        }
    }
}
