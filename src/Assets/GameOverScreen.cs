using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// "forked" from Coco Code https://www.youtube.com/watch?v=K4uOjb5p3Io

public class GameOverScreen : MonoBehaviour
{
    public static bool Casual = false;
    public static bool Training = false;
    public static bool Bonjwa = false;
    // public Text ggText;
    public Text pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }

    public void CasualButton()
    {
        SceneManager.LoadScene("Game");
        circleSpawner.heartsNum = 3;
        Casual = true;
        Training = false;
        Bonjwa = false;
        
        // ggText.color = new Color32(126, 255, 149, 1); 
        // Debug.Log(ggText.color);
        FindObjectOfType<AudioManager>().Play("buttonPress");

    }

    public void TrainingButton()
    {
        SceneManager.LoadScene("Game");
        circleSpawner.heartsNum = 3;
        Casual = false;
        Training = true;
        Bonjwa = false;
        FindObjectOfType<AudioManager>().Play("buttonPress");
    }

    public void BonjwaButton()
    {
        SceneManager.LoadScene("Game");
        circleSpawner.heartsNum = 1;
        circleSpawner.currentHealth = 25;
        Casual = false;
        Training = false;
        Bonjwa = true;
        FindObjectOfType<AudioManager>().Play("buttonPress");        
    }

}


