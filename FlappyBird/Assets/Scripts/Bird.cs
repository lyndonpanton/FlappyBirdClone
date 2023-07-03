using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public float canFlap = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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

        //if (flapping != 0 && Time.fixedTime > canFlap)
        //{

        //    rb2d.AddForce(
        //        new Vector2(0, 1),
        //        ForceMode2D.Impulse
        //    );

        //    canFlap = Time.fixedTime + 0.5f;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
