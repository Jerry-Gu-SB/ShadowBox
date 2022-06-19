using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// code shamelessly "based on" (copied) from Blackthornprod https://www.youtube.com/watch?v=3uyolYVsiWc

public class Hearts : MonoBehaviour
{
    public circleSpawner circleSpawner;

    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Update is called once per frame
    void Update()
    {
        // this sets the number of hearts to the max if there is too much health
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        // runs through the image array of hearts
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health) // checks if this heart should be empty or full
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts) // checks whether the set max health is too low for the heart in the array
            {
                hearts[i].enabled = true;
            }

            else
            {
                hearts[i].enabled = false;
            }

        }

        health = circleSpawner.heartsNum;
    }
}
