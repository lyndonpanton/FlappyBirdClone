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
    private bool isDead = false;

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

        if (!isDead)
        {
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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        KillBird();
    }

    void OnDestroy()
    {
        Debug.Log("Game Over");
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy game object after it falls out of the bottom of the screen
        if (transform.position.y < gameOverPoint)
        {
            KillBird();
        }
    }

    // TODO
    void KillBird()
    {
        // Disable player controls
        isDead = true;
        // Rotate bird sprite so the bird is facing downwards
        rb2d.SetRotation(315);
        // Remove circle collider (so the bird just falls down)
        Destroy(cc2d);
        // Destroy bird after some time
        Destroy(gameObject, 2f);
    }
}
