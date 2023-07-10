using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

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

    public static void IncrementScore(float increment)
    {
        GameObject scoreCanvas = GameObject.FindGameObjectWithTag("Score");
        float currentScore = float.Parse(scoreCanvas.GetComponentInChildren<TextMeshProUGUI>().text, CultureInfo.InvariantCulture);
        currentScore += increment;

        scoreCanvas.GetComponentInChildren<TextMeshProUGUI>().text = currentScore.ToString();
    }

    public static void IncrementScore(int increment)
    {
        GameObject scoreCanvas = GameObject.FindGameObjectWithTag("Score");
        int currentScore = Int32.Parse(scoreCanvas.GetComponentInChildren<TextMeshProUGUI>().text);
        currentScore += increment;

        scoreCanvas.GetComponentInChildren<TextMeshProUGUI>().text = currentScore.ToString();
    }

    public static void QuitToMenu()
    {
        // Exit game completely for now
        Application.Quit();
        // Exit to main menu later...
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void ShowDeathOptions()
    {
        //GameObject deathCanvas = GameObject.FindGameObjectWithTag("deathCanvas");
        //deathCanvas.SetActive(true);
        GameObject deathCanvas = Instantiate(Resources.Load("DeathCanvasPrefab", typeof(GameObject))) as GameObject;
    }
}
