using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPowerJump : MonoBehaviour
{

    public Transform holder;

    public string tag;

    public bool hasPickup;

    public AudioClip powerJump;

    public float losePickUpTime = 10;

    AudioSource audio;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void UseSword()
    {
        audio.PlayOneShot(powerJump);

        //hasSword = false;
        //foreach(Transform t in holder)
        //{
        //    Destroy(t.gameObject);
        //}
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tag))
        {
            collision.transform.parent = holder;
            collision.transform.localPosition = Vector3.zero;
            hasPickup = true;
            StopAllCoroutines();
            StartCoroutine(LosePickUp());
        }
    }

    IEnumerator LosePickUp()
    {
        GetComponent<KittykatMove>().jumpMultiplier = 2;
        yield return new WaitForSeconds(losePickUpTime);
        hasPickup = false;
        foreach(Transform t in holder)
        {
            Destroy(t.gameObject);
        }
        GetComponent<KittykatMove>().jumpMultiplier = 1;
    }

}
