using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// based off of code from Alexander Zotov - https://www.youtube.com/watch?v=vZ0T7mExfhY


public class circleSel : MonoBehaviour
{
    private SpriteRenderer sprRenderer;

    private bool CircleSelected;
    public static bool dragSelectedCirclesAllowed, mouseOverCircle;

    private Vector2 mousePos;
    private float dragOffsetX, dragOffsetY;

    public bool clickme;

    [SerializeField]
    private int xLow = 0, xHigh = 0, yLow = 0, yHigh = 0;

    private Vector3 Position;

    // Start is called before the first frame update

    void Start()
    {
        Position = transform.position;
        sprRenderer = GetComponent<SpriteRenderer>();
        CircleSelected = false;
        // dragSelectedCirclesAllowed = false;  
        mouseOverCircle = false;

    }

    // When BoxSelections collider meets a Circle, Circle changes its color tint to Red
    // and Circle is marked as selected now

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BoxSelection>())
        {
            redCircle();
            CircleSelected = true;
        }
    }

    // When BoxSelection collider stops touching a Circle while left mouse button is still
    // being held down then circle gets its normal color tint and marked as not selected
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BoxSelection>() && Input.GetMouseButton(0))
        {
            returnColor();
            CircleSelected = false;
        }
    }
    private void Update()
    {

        if (circleSpawner.activate)
        {
            retrieveBounds();
            clickme = false;
            returnColor();
        }
        
        if ((Position.x < xHigh && Position.x > xLow) && (Position.y < yHigh && Position.y > yLow)) {
            clickme = true;
        }

        if (clickme) 
        {
            sprRenderer.color = new Color (1f, 1f, 0f, 1f);
        }


        // When left mouse button is clicked I need to get an offset between mouse position
        // and a Circle. This offset will help me to drag Circle/Circles from
        // its/their initial positions depending on mouse position whitout any "jumping" issues

        if (Input.GetMouseButtonDown(0))
        {
            dragOffsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            dragOffsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }

        // And of course I need to get mouse position

        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        //Pretty obvious piece of code I guess :-) If it's not just let me know.

        if (CircleSelected && dragSelectedCirclesAllowed)
        {
            transform.position = new Vector2(mousePos.x - dragOffsetX, mousePos.y - dragOffsetY);
        }


        // If right mouse button is pressed then selection is reset

        if (Input.GetMouseButtonDown(1))
        {
            CircleSelected = false;
            dragSelectedCirclesAllowed = false;
            returnColor();
        }

        // if the circle is selected while not being the right one, lose a life
        if ((!clickme && CircleSelected) && (Input.GetMouseButtonUp(0)))
        {
            CircleSelected = false;
            circleSpawner.currentHealth--;
            FindObjectOfType<AudioManager>().Play("healthLoss");
        }   

        if ((clickme && CircleSelected) && (Input.GetMouseButtonUp(0)))
        {
           
            // circleSpawner.score++;
            // Debug.Log(circleSpawner.score + " SCORE");
            clickme = false;
            CircleSelected = false;
        }
    }

// =========================================================== NOT IN UPDATE

    // No need to explain I hope

    // private void OnMouseDown()
    // {
    //     mouseOverCircle = true;
    // }

    // Same here

    private void OnMouseUp()
    {
        mouseOverCircle = false;
        dragSelectedCirclesAllowed = false;
        
    }

    // Hope it's clear as well

    // private void OnMouseDrag()
    // {
    //     returnColor();

    //     // dragSelectedCirclesAllowed = true;

    //     if (!CircleSelected)
    //     {
    //         dragSelectedCirclesAllowed = false;
    //     }

    //     mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     transform.position = new Vector2(mousePos.x - dragOffsetX, mousePos.y - dragOffsetY);
        
    // }


    private void returnColor()
    {
        sprRenderer.color = new Color (1f, 1f, 1f, 1f);
    }

    private void redCircle()
    {
        sprRenderer.color = new Color (1f, 0f, 0f, 1f);
    }

    private void retrieveBounds()
    {
        xLow = circleSpawner.horizLower;
        xHigh = circleSpawner.horizUpper;
        yLow = circleSpawner.verLower;
        yHigh = circleSpawner.verUpper;

    }

}  
