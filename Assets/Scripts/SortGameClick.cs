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
 *
 *4/6/2019, Krizel Rika Doydora: Initial Implementation
 *4/6/2019, Krizel Rika Doydora: Created Button for clearer Sorting Game Instruction
 * */
#endregion
#endregion
using UnityEngine;
using System.Collections;

public class SortGameClick : MonoBehaviour
{
    bool showInstruction = false;
    private Texture img;

    /**Method Name: Start
    * Parameters: N/A
    * Returns: N/A
    * 
    * A built-in unity function inherted from MonoBehaviour.
    * This is activated upon start-up before Start() to set the scene.
    * Starts up the Sorting Game Instruction.
    * */
    private void Start()
    {
        img = Resources.Load<Texture2D>("Sort");

    }


    /**Method Name: Start
    * Parameters: N/A
    * Returns: N/A
    * 
    * This method controls if method should be shown or not.
    * */   
    public void ClickTest()
    {
        Debug.Log("Clicked");
        showInstruction = !showInstruction;
        Debug.Log(showInstruction);
    }

    /**Method Name: OnGUI
    * Parameters: N/A
    * Returns: N/A
    * 
    * A built-in unity function.
    * Used for rendering and handling GUI events.
    * */
    public void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 50;
        myStyle.normal.textColor = Color.white;
        if (showInstruction)
        {
            GUI.BeginGroup(new Rect(Screen.width / 2 - 150, 50, 300, 300));

            GUI.DrawTexture(new Rect(0, 0, 300, 300), img);

            GUI.EndGroup();
        }
    }


}
