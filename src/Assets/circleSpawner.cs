using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleSpawner : MonoBehaviour
{

    public Transform Parent;
    public GameObject Circle;

    public GameOverScreen GameOverScreen;

    public float interval = 3.0f;
    public float timer = 0f;
    public int intervalNum = 0;

    public static int horizLower = 0, horizUpper = 0, verLower = 0, verUpper = 0;
    public static bool activate = false;  
    
    public static int currentHealth = 100;
    public static int maxHealth = 100;
    public static int heartsNum = 3;

    public static int score = 0;
    public int clickMeNum = 0;

    // Start is called before the first frame update
    void Start()
    {   
        score = 0;
        timer = interval;
        SpawnCircles();
        activation();
        intervalNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0 || heartsNum <= 0)
        {
            GameOver();
        }

        timer -= Time.deltaTime;
            
        if (activate)
        {
            activation();
        }

        noClickMe();
    }

    public void SpawnCircles()
    {
        
        for (int x = -8; x < 9; x++)
        {
            for (int y = -4; y < 5; y++)
            {
                Instantiate(Circle, new Vector3(x, y, 0f), Quaternion.identity, Parent);
            }
        }
    }

    public void noClickMe()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Circle");
        bool allAreFalse = true;

        foreach (GameObject obj in taggedObjects) 
        {
            if (obj.GetComponent<circleSel>().clickme) 
            {
                allAreFalse = false;
                break;
            }
            
        }

        if (allAreFalse) 
        {
            if (clickMeNum > 0)
            {
                FindObjectOfType<AudioManager>().Play("pop");
            }    
 
            score += clickMeNum;
            activate = true;
            
        }

        else if (timer < 0)
        {
            // audio "miss" is from ZapSplat.com
            if (GameOverScreen.Casual || GameOverScreen.Training || GameOverScreen.Bonjwa)
            {
                FindObjectOfType<AudioManager>().Play("miss");
            }
            activate = true;
            heartsNum--;
        }
        else 
        {
            activate = false;
        }

    }

    public void activation()
    {
        
        horizLower = Random.Range(-9, 8);
        horizUpper = Random.Range(horizLower + 1, 10);
        verLower = Random.Range(-5, 4);
        verUpper = Random.Range(verLower + 1, 6);
        
        intervalNum += 1;
        if (GameOverScreen.Bonjwa && interval > 1) 
        {
            interval -= Mathf.Log(intervalNum, 2) * .005f;
            Debug.Log(interval);
        }

        else if(GameOverScreen.Training && interval > 1)
        {
            interval -= Mathf.Log(intervalNum, 2) * .002f;
            Debug.Log(interval);
        }

        timer = interval; 
        activate = false;

        clickMeNum = 0;
        GameObject[] clickmeCircles = GameObject.FindGameObjectsWithTag("Circle");
        foreach (GameObject circle in clickmeCircles)
        {
            if (circle.GetComponent<circleSel>().clickme)
            {
                clickMeNum ++;
            }
        }
    }

    public void GameOver()
    {
        interval = 3f;
        timer = interval;
        currentHealth = maxHealth;

        GameOverScreen.Setup(score);
    }
}
