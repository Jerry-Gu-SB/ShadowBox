using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartScreenScript : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void Update()
    {
        if (GameOverScreen.Casual || GameOverScreen.Training || GameOverScreen.Bonjwa)
        {
            gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Play("buttonPress");
        }
    }

}
