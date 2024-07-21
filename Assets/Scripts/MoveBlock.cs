using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{

    public float speed;

    public float distance;

    Vector3 from, to;

    bool moveRight = true;

    float distanceTravelled;


    // Start is called before the first frame update
    void Start()
    {
        from = transform.position;
        to = from + Vector3.right * distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        distanceTravelled += speed * Time.deltaTime;
        if(distanceTravelled >= distance)
        {
            moveRight = !moveRight;
            distanceTravelled = 0;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * distance);
    }
}
