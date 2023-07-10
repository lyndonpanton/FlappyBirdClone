using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ShowDeathOptions()
    {
        //GameObject deathCanvas = GameObject.FindGameObjectWithTag("deathCanvas");
        //deathCanvas.SetActive(true);
        GameObject deathCanvas = Instantiate(Resources.Load("DeathCanvasPrefab", typeof(GameObject))) as GameObject;
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void QuitToMenu()
    {
        // Exit game completely for now
        Application.Quit();
    }
}
