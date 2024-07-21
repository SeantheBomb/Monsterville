using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAroundAndChaseYou : MonoBehaviour
{

    public float speed;

    public Transform kitty;

    public AudioClip growl, gameOver;

    AudioSource audio;

    private void Start()
    {
        kitty = GameObject.FindGameObjectWithTag("Player").transform;
        audio = GetComponent<AudioSource>();
        StartCoroutine(LoopAudio());
    }

    IEnumerator LoopAudio()
    {
        while (enabled)
        {
            if (Vector3.Distance(transform.position, kitty.transform.position) < 3)
            {
                audio.PlayOneShot(growl);
            }
            yield return new WaitForSeconds(5f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 delta = kitty.position - transform.position;
        transform.position += delta.normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out PickUpSword sword))
        {
            if (sword.hasSword)
            {
                Destroy(gameObject);
                sword.UseSword();
            }
            else
            {
                //Destroy(other.gameObject);
                GameOverScreen.ShowLoseScreen();
                //Kill the player!
                audio.PlayOneShot(gameOver);
            }
        }
    }
}
