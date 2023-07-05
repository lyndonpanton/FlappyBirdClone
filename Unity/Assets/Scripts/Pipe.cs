using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}