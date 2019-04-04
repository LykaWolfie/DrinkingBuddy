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
 * This file dictates the class variable for easier referencing
 * 
 * 2/20/2019, Carlo La Rosa: Initial Implementation
 * 2/20/2019, Carlo La Rosa: Sprite Spawning
 * 2/21/2019, Carlo La Rosa: Scoring System
 * 3/6/2019, Andrei Fernandez: Added EndGame
 * 4/3/2019, Andrei Fernandez: GUIstyle
 * */
#endregion
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SortingGame : MonoBehaviour {
    //int FoodType: serves as the index in the array of sprite pictures, the value is "0" if the current sprite is the Milkshake and "1" if Pancake
    //int score: stores the user's game score
    //int count: counts how many rounds the game has went, maximum of 20
    private int FoodType, score = 0, count = 0;
    //array of the sprite pictures
    public Sprite[] Sprite_Pic;
    bool ended = false;
    GUIStyle style = new GUIStyle();
    /**Method Name: Start
    * Parameters: N/A
    * Returns: N/A
    * 
    * A built-in unity function inherted from MonoBehaviour.
    * This is activated upon start-up before Start() to set the scene.
    * Starts up the Sorting Game.
    * */
    void Start() {
        //sets the scale and the initial position of the first sprite
        transform.localScale = new Vector2(80, 85);
        transform.position = new Vector2(0, 0);
        //randomizes the value of FoodType
        FoodType = Random.Range(0, Sprite_Pic.Length);
        //uses the sprite picture based on the index FoodType
        GetComponent<SpriteRenderer>().sprite = Sprite_Pic[FoodType];
    }

    /**Method Name: Update
    * Parameters: N/A
    * Returns: N/A
    * 
    * A built-in unity function inherted from MonoBehaviour.
    * This is activated once per frame.
    * Checks the current score and counts the current rounds.
    * */
    void Update() {
        Debug.Log(count);
        if (count < 15) {//if the left mouse button isup, this condition will trigger the checking only after the user has finished dragging
            if (Input.GetMouseButtonUp(0)) {
                //checks if the position of the sprite is within the range of accepted values on the right side
                if ((transform.position.x > 120) && (transform.position.y < 100) && (transform.position.y > -100)) {
                    //checks for the correct sprite
                    if (FoodType == 1) {
                        score++;
                    }
                    else {
                        if (score > 0) {
                            score--;
                        }
                    }
                    //increment the game round and restart
                    count++;
                    Start();
                }
                //checks if the position of the sprite is within the range of accepted values on the left side
                else if ((transform.position.x < -120) && (transform.position.y < 100) && (transform.position.y > -100)) {
                    //checks for the correct sprite
                    if (FoodType == 0) {
                        score++;
                    }
                    else {
                        if (score > 0) {
                            score--;
                        }
                    }
                    //increment the game round and restart
                    count++;
                    Start();
                }
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
    void OnGUI() {
        style.fontSize = 30;
        style.normal.textColor = Color.white;
        style.alignment = TextAnchor.MiddleCenter;
        //prints the current score and the game instructions
        GUI.Label(new Rect(100,150, 600, 600), "SCORE: " + score + "\nThe KITTY gets the MILKSHAKE\nThe BUNNY gets the PANCAKE", style);

        if (count >= 15) {
            if (score >= 9) {
                GUI.Label((new Rect(100, 50, 600, 600)), "YOU PASS!", style);
            }
            else if (!StartGame.Practice()) {
                SendSMS.Send("Hello!");
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