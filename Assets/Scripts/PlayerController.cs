using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(x, 0, z);
        if (moveDir == Vector3.zero)
            return;

        transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.World);

        Quaternion lookRot = Quaternion.LookRotation(moveDir);
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, rotateSpeed);
    }
}
