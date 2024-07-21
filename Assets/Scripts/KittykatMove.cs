using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittykatMove : MonoBehaviour
{

    public float speed = 1f;

    public float jumpForce = 100f;

    public AudioClip meow;

    Rigidbody2D rb;

    AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            //rb.MovePosition(rb.position + Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            //rb.MovePosition(rb.position + Vector2.right * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * jumpForce);
            audio.PlayOneShot(meow);
        }
    }
}
