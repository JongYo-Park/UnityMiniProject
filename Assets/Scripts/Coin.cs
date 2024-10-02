using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    [SerializeField] int score = 1;
    [SerializeField] float rotateSpeed = 50f;

    private ScoreManager scoreManager;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.Play();
            Debug.Log($"ÄÚÀÎ È¹µæ, Á¡¼ö {score} È¹µæ");
            StartCoroutine(DestroyCoinAfterSound());
        }
    }
    private IEnumerator DestroyCoinAfterSound()
    {
        yield return new WaitForSeconds(audioSource.clip.length - 0.5f);
        Destroy(gameObject);
    }
}
