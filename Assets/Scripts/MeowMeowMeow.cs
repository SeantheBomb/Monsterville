using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeowMeowMeow : MonoBehaviour
{

    public GameObject crown;

    public AudioClip clip;

    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") == false)
        {
            return;
        }
        Instantiate(crown, transform.position, transform.rotation);
        Destroy(gameObject);
        other.GetComponent<KittykatHealth>().WinGame();
        GameOverScreen.ShowWinScreen();
        audio.PlayOneShot(clip);
    }

}
