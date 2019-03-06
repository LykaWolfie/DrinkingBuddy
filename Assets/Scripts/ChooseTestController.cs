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
 * Created: 1/28/2019 by Drinking Buddy Group for the Party People.
 * This file acts as a Controller which handles input and feedback for
 * pre-setting tests to be played upon drinking
 * 
 * 1/28/2019, Andrei Fernandez: Added TestClick
 * 2/1/2019, Andrei Fernandez: Added Activate which displays the Choose Test Mode
 * 2/8/2019, Andrei Fernandez: Added Confirm for saving, Edited TestClick and Activate
 * to implement highlighting system
 * 3/6/2018, Andrei Fernandez: Added Practice test function inside TestClick()
 * */
#endregion
#endregion

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChooseTestController : MonoBehaviour {
    //size determines number of buttons, chosen determines if a test is activated, CTmode is on/off
    public int size;
    public GameObject OK,panel;
    public EventSystem ES;
    private bool[] chosen, temp;
    private bool CTmode;

    /**Method Name: Start
     * Parameters: N/A
     * Returns: N/A
     * 
     * A built-in unity function inherted from MonoBehaviour.
     * This is activated upon start-up before Start() to set the scene.
     * Loads selected tests.
     * */
    private void Start() {
        chosen = SaveSystem.LoadCT();
        if (chosen == null || chosen.Length != size) {
            chosen = new bool[size];
        }
        
        temp = chosen;
    }

    /**Method Name: TestClick
     * Parameters: N/A
     * Returns: N/A
     * 
     * This function flips boolean values and switches button colors to indicate selection.
     * Called by all test buttons.
     * */
    public void TestClick() {  
        //check if in CT mode
        if (CTmode) {
            //Takes button clicked
            GameObject buttonClicked = ES.currentSelectedGameObject; 
            //change color of button
            if(buttonClicked.GetComponent<Image>().color == Color.white) {
                buttonClicked.GetComponent<Image>().color = new Color(1, (float)0.95, (float)0.5);
            }
            else {
                buttonClicked.GetComponent<Image>().color = Color.white;
            }
            //buttons are named 1,2,3,...,n
            int testNumber = int.Parse(buttonClicked.name);
            //testNumber-1 for indexing
            temp[testNumber - 1] = !temp[testNumber - 1];
        }
        //this is for practice test
        else {
            Debug.Log("HEllo");
            Debug.Log(ES.currentSelectedGameObject.name);
            StartGame.ChangeToGameScene(int.Parse(ES.currentSelectedGameObject.name));
        }
    }

    /**Method Name: Activate
     * Parameters: N/A
     * Returns: N/A
     * 
     * Toggles Choose Test mode. Sets and Resets the screen.
     * Called by Choose Test button and OK button
     * */
    public void Activate() {
        CTmode = !CTmode;
        //Enables OK button, disables lower panel, and changes Choose Test to Cancel
        if (CTmode) {
            OK.SetActive(true);
            panel.SetActive(false);
            transform.Find("ChooseTest").GetComponentInChildren<Text>().text = "Cancel";
            //For every true, highlight appropriate button
            for (int i = 0; i < size; i++) {
                if (chosen[i]) {
                    transform.Find((i+1).ToString()).GetComponent<Image>().color = new Color(1, (float)0.95, (float)0.5);
                }
            }
        }
        //Reverses UI changes to default
        else {
            OK.SetActive(false);
            panel.SetActive(true);
            transform.Find("ChooseTest").GetComponentInChildren<Text>().text = "Choose Test";
            for(int i = 1; i <= size; i++) {
                transform.Find((i).ToString()).GetComponent<Image>().color = Color.white;
            }
        }
    }
    /**Method Name: Confirm
     * Parameters: N/A
     * Returns: N/A
     * 
     * Saves all changes in test mode.
     * Called by OK button.
     * */
    public void Confirm() {
        chosen = temp;
        SaveSystem.SaveCT(chosen);
    }

    public void TakeTest() {
        StartGame.ChangeToGameScene(chosen);
    }

}
