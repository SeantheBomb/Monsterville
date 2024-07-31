using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAroundAndChaseYou : MonoBehaviour
{

    public float speed;

    public int damage = 1;

    bool canAttack = true;

    public float attackSpeed = 1f;

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
        if (Vector3.Distance(transform.position, kitty.transform.position) > 10)
            return;

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
                //GameOverScreen.ShowLoseScreen();
                AttackPlayer();
                //Kill the player!
                //audio.PlayOneShot(gameOver);
            }
        }
    }


    void AttackPlayer()
    {
        if (canAttack)
        {
            KittykatHealth.AttackKitty(damage);
            StartCoroutine(WaitToAttack());
        }
    }

    IEnumerator WaitToAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(speed);
        canAttack = true;
    }
}
