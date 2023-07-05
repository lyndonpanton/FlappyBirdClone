using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject[] pipePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < pipePrefabs.Length; i++)
        {
            pipePrefabs[i].AddComponent<Pipe>();
        }

        int randomIndex = Random.Range(0, pipePrefabs.Length);


        GameObject pipeTop = Instantiate(
            pipePrefabs[randomIndex],
            new Vector2(1, 0),
            Quaternion.identity
        );

        // 0 - 6
        // 1 - 5
        // 2 - 4
        // 3 - 3
        // 4 - 2
        // 5 - 1
        // 6 - 0
        GameObject pipeBottom = Instantiate(
            pipePrefabs[Mathf.Abs(randomIndex - (pipePrefabs.Length - 1))],
            new Vector2(-1, 0),
            Quaternion.identity
        );

        // TODO
        // Spawn bottom pipe at the bottom of the screen
        // Rotation -> flip z -> move

        pipeTop.transform.localScale *= 8;
        pipeBottom.transform.localScale *= 8;
    }

    // Update is called once per frame
    void Update()
    {
        // Add pipe pair every x seconds
    }
}
