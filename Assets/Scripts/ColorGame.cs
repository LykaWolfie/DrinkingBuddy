﻿#region Preamble
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
 * Created: 3/6/2019 by Drinking Buddy Group for the Party People.
 * This file dictates the class variable for easier referencing
 * 
 * 3/6/2019, Carlo La Rosa: Initial Implementation and Sprite Creation
 * 3/7/2019, Carlo La Rosa: Sprite Spawning and Incorporation of Buttons
 * 3/8/2019, Carlo La Rosa: Scoring System
 * 3/8/2019, Andrei Fernandez: Added EndGame
 * 4/3/2019, Andrei Fernandez: GUIstyle
 * 4/6/2019, Krizel Rika Doydora: Added Pause Game
 * */
#endregion
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorGame : MonoBehaviour {
    //int score: stores the user's game score
    //int count: counts how many rounds the game has went, maximum of 15
    //int ans: stores the user's answer, "-1" if Wrong, and "1" if Correct
    //int c: stores the index of the Color sprite
    //int w: stores the index of the Word sprite
    private int score = 0, count = 0, ans = 0, c, w;
    bool is_game_paused = false;

    //GameObject Color: pertains to the Color sprite
    //GameObject Word: pertains to the Word sprite
    //GameObject Answer: pertains to the Game Object handling answer buttons
    public GameObject Color, Word, Answer;

    //indicates if game has ended
    bool ended = false;
    GUIStyle style = new GUIStyle();

    /**Method Name: Start
    * Parameters: N/A
    * Returns: N/A
    * 
    * A built-in unity function inherted from MonoBehaviour.
    * This is activated upon start-up before Start() to set the scene.
    * Starts up the Color Game.
    * */
    void Start() {
        //calls the Start function of Color sprite spawn and the Word sprite spawn to create a random pair of Color and Word sprites
        Color.GetComponent<ColorSpawn>().Start();
        Word.GetComponent<ColorSpawn>().Start();
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
    void Update() {
        //check if game count is not max
        if (!is_game_paused){
            if (count < 15)
            {
                //store the user's answer
                ans = Answer.GetComponent<ColorButtons>().answer;
                //store the index of Color sprite
                c = Color.GetComponent<ColorSpawn>().Val;
                //store the index of Word sprite
                w = Word.GetComponent<ColorSpawn>().Val;

                //c modulo 4 (there are four colors) should be equal to w to signify a correct pair of sprites to which ans = 1
                //if the pair is incorrect, then ans = -1
                if (((c % 4 == w) && (ans == 1)) || ((c % 4 != w) && (ans == -1)))
                {
                    Debug.Log("Correct answer");
                    count++;
                    score++;
                    //set the user answer back to 0, the neutral state while waiting for the new answer for the next pair
                    Answer.GetComponent<ColorButtons>().answer = 0;
                    //respawn new sprite pair
                    Start();
                }
                //the case the user's answer is incorrect
                else if (((c % 4 == w) && (ans == -1)) || ((c % 4 != w) && (ans == 1)))
                {
                    Debug.Log("Incorrect answer");
                    count++;
                    //right minus wrong
                    if (score == 0)
                    {
                        score = 0;
                    }
                    else
                    {
                        score--;
                    }
                    //set the user answer back to 0, the neutral state while waiting for the new answer for the next pair
                    Answer.GetComponent<ColorButtons>().answer = 0;
                    //respawn new sprite pair
                    Start();
                }
            }
            //Word.GetComponent<Word>
        }
    }

    /**Method Name: OnGUI
    * Parameters: N/A
    * Returns: N/A
    * 
    * A built-in unity function.
    * Used for rendering and handling GUI events.
    * */
    void OnGUI() {
        style.fontSize = 100;
        style.alignment = TextAnchor.MiddleCenter;
        //prints the current score and the game instructions
        GUI.Label(new Rect(100, (Screen.height / 2)-70, 600, 600), "SCORE: " + score+ "", style);
        

        //check if game count is not max
        if (count >= 15) {
            //check if user has passing score
            if (score >= 9) {
                GUI.Label((new Rect(100, (Screen.height / 2), 600, 600)), "YOU PASS!",style);
            }
            else if (!StartGame.Practice()) {
                SendSMS.Send("Hello!");
                Debug.Log("LOSE");
                GUI.Label((new Rect(100, (Screen.height / 2), 600, 600)), "YOU FAIL!",style);
                count = 0;
                score = 0;
            }
            //this is to avoid multiple calls of EndGame
            if (!ended) {
                //flips bit so that it wont enter this conditional again
                ended = !ended;
                //calls EndGame after 3 seconds
                Invoke("EndGame", 3);
            }
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



    /**Method Name: EndGame
    * Parameters: N/A
    * Returns: N/A
    * 
    * Loads the next scene, effectively ending the game
    * */
    void EndGame() {
        StartGame.LoadNext();
    }

}