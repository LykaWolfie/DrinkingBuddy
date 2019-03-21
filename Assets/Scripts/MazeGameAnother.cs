#region Preamble
#region License
/**
 * Copyright (C) 2019 La Rosa, Fernandez, Doydora - All Rights Reserved
 * You may use, distribute and modify this code under the
 * terms of the GNU GPL-3.0 license.
 *
 * You should have received a copy of the GNU GPL-3.0 license with
 * this file.
 * 
 * This is a course requirement for CS 192 Software Engineering II
 * under the supervision of Asst. Prof. Ma. Rowena C. Solamo of the
 * Department of Computer Science, College of Engineering,
 * University of the Philippines, Diliman
 * for the AY 2018-2019
 * */
#endregion

#region Code History
/**
 * Created: 3/21/2019 by Drinking Buddy Group for the Party People.
 * This file dictates the class variable for easier referencing
 * 
 * 2/18/2019, Krizel Doydora: Initial Implementation
 * 2/20/2019, Krizel Doydora: Player Dragging
 * 2/21/2019, Krizel Doydora: Maze and Player colliders
 * */
#endregion
#endregion

using UnityEngine;
using System.Collections;
using System;

public class MazeGameAnother : MonoBehaviour
{
    // bool dragging, wall_is_touched, and reached_end are used to check 
    // if events (as variable names suggesst) have happened
    // mouseStartPos and playerStartPos are just initiallization 
    // for positions of mouse and player real time
    bool dragging = false;
    Vector3 mouseStartPos;
    Vector3 playerStartPos;
    bool wall_is_touched = false;
    bool reached_end = false;
    bool ended = false;

    /**Method Name: Start
    * Parameters: N/A
    * Returns: N/A
    * 
    * A built-in unity function inherted from MonoBehaviour.
    * Starts up the Maze Game.
    * */
    void Start()
    {

    }

    /**Method Name: FixedUpdate
   * Parameters: N/A
   * Returns: N/A
   * 
   * A built-in unity function inherted from MonoBehaviour.
   * This is activated once per frame.
   * Checks if ball is being dragged and updates sprite position accordingly
   * */
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragging = true;
            mouseStartPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            playerStartPos = transform.position;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }

        if (dragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            Vector3 move = mousePos - mouseStartPos;
            transform.position = playerStartPos + move;
            //NOTE: THIS IS THE END.... FINISHED THE GAME :)
            if ((transform.position.x < (float) -4) && (transform.position.y > (float)-1))
            {
                reached_end = true;
               
            }

         
        }

    }

    /**Method Name: OnGUI
    * Parameters: N/A
    * Returns: N/A
    * 
    * A built-in unity function.
    * Used for rendering and handling GUI events.
    * */
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), "Try to Finish the Maze");

        if (wall_is_touched)
        {
            //GUI.Label(new Rect(10, 80, 100, 100), "You failed -_-");
            if (!StartGame.Practice())
            {
                SendSMS.Send("Sadt..");
                wall_is_touched = false;
                reached_end = false;

            }

            // prevents multiple cals of EndGame
            if (!ended)
            {
                ended = !ended;
                Invoke("EndGame", 3);

            }
        } 
        else if (reached_end && (!wall_is_touched))
        {
            GUI.Label(new Rect(10, 50, 100, 100), "DONE!!!!!!!!");

            if (!ended)
            {
                ended = !ended;
                Invoke("EndGame", 3);
            }
        }

    }

    /**Method Name: OnTriggerEnter2D
    * Parameters: Collider2D 
    * Returns: N/A
    * 
    * A built-in unity function.
    * Used for checking if the ball hits the maze collider usings 2D colliders
    * */
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Touched wall");
        Debug.Log(other);
        wall_is_touched = true;
    }

    /**Method Name: EndGame
   * Parameters: N/A
   * Returns: N/A
   * 
   * Loads the next scene, effectively ending the game
   * */
    void EndGame()
    {
        StartGame.LoadNext();
    }

}
