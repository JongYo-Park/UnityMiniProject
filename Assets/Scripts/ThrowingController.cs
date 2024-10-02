using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingController : MonoBehaviour
{
    [SerializeField] GameObject rockPrefab;
    [SerializeField] Transform throwingPoint;
    [SerializeField] float rockTime = 2f;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Throw();
        }
    }

    private void Throw()
    {
        GameObject rock = Instantiate(rockPrefab, throwingPoint.position, throwingPoint.rotation);

        StartCoroutine(DestroyRockAfterTime(rock, rockTime));
    }

    private IEnumerator DestroyRockAfterTime(GameObject rock, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(rock);
    }
}
