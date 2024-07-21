using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSword : MonoBehaviour
{

    public Transform holder;

    public string swordTag;

    public bool hasSword;

    public AudioClip killMonster;

    public float loseSwordTime = 10;

    AudioSource audio;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void UseSword()
    {
        audio.PlayOneShot(killMonster);

        //hasSword = false;
        //foreach(Transform t in holder)
        //{
        //    Destroy(t.gameObject);
        //}
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(swordTag))
        {
            collision.transform.parent = holder;
            collision.transform.localPosition = Vector3.zero;
            hasSword = true;
            StartCoroutine(LoseSword());
        }
    }

    IEnumerator LoseSword()
    {
        yield return new WaitForSeconds(loseSwordTime);
        hasSword = false;
        foreach(Transform t in holder)
        {
            Destroy(t.gameObject);
        }
    }

}
