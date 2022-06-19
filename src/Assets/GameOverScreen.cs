using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// "forked" from Coco Code https://www.youtube.com/watch?v=K4uOjb5p3Io

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;

    public void Setup(int score){
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
        circleSpawner.heartsNum = 3;
    }

}


