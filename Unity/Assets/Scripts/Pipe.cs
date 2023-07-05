using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Pipe : MonoBehaviour
{
    public float pipeDestroyPoint;
    public BoxCollider2D bc2d;

    // Start is called before the first frame update
    void Start()
    {


        GameObject camera = GameObject.Find("Main Camera");
        // Top collider, reversing will given the y coordinate of the bottom of
        // the camera
        float leftBound = -camera.GetComponent<EdgeCollider2D>().points[1].x;

        // Get box collider
        bc2d = GetComponent<BoxCollider2D>();
        // Position bird needs to be in to trigger game over
        pipeDestroyPoint = leftBound - bc2d.size.x;
    }

    void FixedUpdate()
    {
        if (transform.position.x < pipeDestroyPoint)
        {
            KillPipe();
        }
        // Flipped sprites go in the opposite direction
        if (gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            gameObject.transform.Translate(
                new Vector3(0.05f, 0f)
            );
        }
        else
        {
            gameObject.transform.Translate(
                new Vector3(-0.05f, 0f)
            );
        }
    }

    void KillPipe()
    {
        Destroy(gameObject);
    }
}