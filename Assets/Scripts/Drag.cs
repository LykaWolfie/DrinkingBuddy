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
 * Created: 2/20/2019 by Drinking Buddy Group for the Party People.
 * This file allows the game sprites to be dragged.
 * 
 * 2/20/2019, Carlo La Rosa: Implementation and Completion
 * */
#endregion
#endregion


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    //standard z position of the mouse
    bool is_game_paused = false;
    float distance = 10;

    /**Method Name: OnMouseDrag
     * Parameters: N/A
     * Returns: N/A
     * 
     * A built-in unity function.
     * This is activated upon the dragging the mouse button.
     * 
     * Reference:
     * IC0DE - How To Drag 2D/3D Object Unity [Tutorial]
     * link: https://www.youtube.com/watch?v=JrNl8JN3_H4
     * */
    void OnMouseDrag()
    {
       if (!is_game_paused) {
            //vector variable that saves the x and y position of the mouse
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            //converts the mouse position to a position on the screen
            Vector3 spritePos = Camera.main.ScreenToWorldPoint(mousePosition);
            //changes the sprite position
            transform.position = spritePos;
        }
    }

    /**Method Name: pauseButton
   * Parameters: N/A
   * Returns: N/A
   * 
   * Switches boolean to pause dragging.
   * */
    public void pauseButton()
    {
        is_game_paused = !is_game_paused;
    }


}
