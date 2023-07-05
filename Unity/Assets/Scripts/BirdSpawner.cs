using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject bird = Instantiate(
            birdPrefab,
            new Vector2(0, 0),
            Quaternion.identity
        );

        bird.transform.localScale *= 8;
        bird.AddComponent<Bird>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
