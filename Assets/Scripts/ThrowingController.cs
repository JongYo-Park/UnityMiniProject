using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingController : MonoBehaviour
{
    [SerializeField] GameObject rockPrefab;
    [SerializeField] Transform ThrowingPoint;
    [SerializeField] float rockTime = 0.5f;

    private Coroutine throwingCoroutine;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (throwingCoroutine == null)
            {
                throwingCoroutine = StartCoroutine(ThrowCoroutine());
            }
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            if (throwingCoroutine != null)
            {
                StopCoroutine(throwingCoroutine);
                throwingCoroutine = null;
            }
        }
    }



    private void Throw()
    {
        GameObject rock = Instantiate(rockPrefab, ThrowingPoint.position, ThrowingPoint.rotation);
        Rock rocks = rock.GetComponent<Rock>();
        Debug.Log("돌 던지기");
    }

    IEnumerator ThrowCoroutine()
    {
        yield return new WaitForSeconds(2f);

        WaitForSeconds delay = new WaitForSeconds(rockTime);

        while (true)
        {
            Throw();
            yield return delay;
        }
    }
}
