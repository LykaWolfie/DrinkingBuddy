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
 * Created: 3/7/2019 by Drinking Buddy Group for the Party People.
 * This file dictates the class variable for easier referencing
 * 
 * 3/7/2019, Carlo La Rosa: Button Creation
 * 3/7/2019, Carlo La Rosa: Incorporation into Color Game
 * 4/6/2019, Krizel Rika Doydora: Added Game Pause
 * */
#endregion
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButtons : MonoBehaviour
{
    //int answer: stores the user's answer
    //answer = 0 means no answer yet
    //answer = 1 means answer is "Correct"
    //answer = -1 means answer is "Wrong"
    public int answer=0;
    bool is_game_paused = false;

    //Button correct: the button that pertains to the user answer "Correct"
    //Button wrong: the button that pertains to the user answer "Wrong"
    public Button correct, wrong;

    /**Method Name: Start
    * Parameters: N/A
    * Returns: N/A
    * 
    * A built-in unity function inherted from MonoBehaviour.
    * This is activated upon start-up before Start() to set the scene.
    * Links the game buttons to the functions they execute upon clicking them.
    * */
    void Start()
    {
        if (!is_game_paused) {
            correct.onClick.AddListener(AnswerCorrect);
            wrong.onClick.AddListener(AnswerWrong);
        }
    }

    /**Method Name: Update
    * Parameters: N/A
    * Returns: N/A
    * 
    * A built-in unity function inherted from MonoBehaviour.
    * This is activated once per frame.
    * Checks if the user answers correctly.
    * Updates the score and game count accordingly.
    * */
    void Update()
    {
        
    }

    /**Method Name: AnswerCorrect
    * Parameters: N/A
    * Returns: N/A
    * 
    * A built-in unity function inherted from MonoBehaviour.
    * This is activated once per frame.
    * Used by the Correct button.
    * Sets answer value to 1.
    * */
    void AnswerCorrect()
    {
        if (!is_game_paused){
            answer = 1;
            Debug.Log("1");
        }
        else{
            answer = 0;
        }
    }

    /**Method Name: AnswerWrong
    * Parameters: N/A
    * Returns: N/A
    * 
    * A built-in unity function inherted from MonoBehaviour.
    * This is activated once per frame.
    * Used by the Wrong button
    * Sets answer value to -1.
    * */
    void AnswerWrong()
    {
        if (!is_game_paused){
            answer = -1;
            Debug.Log("0");
        }
        else{
            answer = 0;
        }
    }

    /**Method Name: pauseButton
    * Parameters: N/A
    * Returns: N/A
    * 
    * Switches boolean to pause the Color Game.
    * */
    public void pauseButton()
    {
        is_game_paused = !is_game_paused;
    }
}
