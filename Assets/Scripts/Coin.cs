using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    [SerializeField] int score = 1;
    [SerializeField] float rotateSpeed = 50f;

    private ScoreManager scoreManager;


    private void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log($"ÄÚÀÎ È¹µæ, Á¡¼ö {score} È¹µæ");
            Destroy(gameObject);
        }
    }
}
