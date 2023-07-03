using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public CircleCollider2D cc2d;

    public float canFlap = 0f;

    public float gameOverPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        GameObject camera = GameObject.Find("Main Camera");
        // Top collider, reversing will given the y coordinate of the bottom of
        // the camera
        float lowerBound = -camera.GetComponent<EdgeCollider2D>().points[0].y;

        // Get radius of circle collider
        cc2d = GetComponent<CircleCollider2D>();
        // Position bird needs to be in to trigger game over
        gameOverPoint = lowerBound - cc2d.radius;
    }

    void FixedUpdate()
    {
        float flapping = Input.GetAxis("Jump");

        if (flapping != 0)
        {
            rb2d.SetRotation(45);
            rb2d.AddForce(
                new Vector2(0, 1.5f),
                ForceMode2D.Impulse
            );
        }
        else
        {
            rb2d.SetRotation(0);
        }
    }

    void OnDestroy()
    {
        Debug.Log("Game Over");
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy bird if y position < lowerBound - circle collider radius
        if (transform.position.y < gameOverPoint)
        {
            Destroy(gameObject);
        }
    }
}
