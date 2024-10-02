using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;
    [SerializeField] float rockSpeed = 10f;
    [SerializeField] int damage = 1;

    private void Start()
    {
        rigid.velocity = transform.forward * rockSpeed;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Monster monster = collision.gameObject.GetComponent<Monster>();
            monster.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

}
