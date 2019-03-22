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
 * Created: 3/13/2019 by Drinking Buddy Group for the Party People.
 * This is the script for the memory game
 * 
 * 3/13/2019, Andrei Fernandez: Initial implementation, randomization, show sequence, block click (for future use)
 * 3/15/2019, Andrei Fernandez: Added spawn
 * 3/19/2019, Andrei Fernandez: Edited spawned prefabs to be buttons, Fixed all functions to be coroutine compatible
 * 3/22/2019, Andrei Fernandez: Changed from 4x4 to 3x3
 * */
#endregion
#endregion

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MemoryGame : MonoBehaviour {
    public EventSystem ES;
    public GameObject MemoryBlock;
    int clickNum,tries = 5;
    bool ended, coroutine;
    int[] sequence = {0,1, 2, 3, 4, 5, 6, 7, 8};

    /**Method Name: Start
    * Parameters: N/A
    * Returns: N/A
    * 
    * A built-in unity function inherted from MonoBehaviour.
    * This is activated upon start-up to set the scene.
    * This randomizes the sequence list and spawns the objects
    * */
    private void Start() {
        //randomization function
        for(int i = 0; i < sequence.Length; i++) {
            var rand = Random.Range(0, i);
            var tmp = sequence[i];
            sequence[i] = sequence[rand];
            sequence[rand] = tmp;

            Debug.Log(sequence[i]);
        }
        //spawn
        for (int x = 0; x < sequence.Length; x++) {
            GameObject block = Instantiate(MemoryBlock) as GameObject;
            block.SetActive(true);
            //each block is named as an integer
            block.name = x.ToString();
            //Anchors the objects to the screen to avoid displacement
            block.transform.SetParent(this.transform);
            //Sets the position of the object relative to the anchor(Top-left)
            block.GetComponent<RectTransform>().anchoredPosition = new Vector2(((x%3)+1)*(800/4), -(((x/3)+1)*(1280/4)));
        }
        //shows the sequence to the player
        StartCoroutine(ShowSequence());
    }
    /**Method Name: ShowSequence()
    * Parameters: N/A
    * Returns: IEnumerator
    * 
    * An IEnumerator is a unity type which enables the use of coroutines and time delays
    * Highlights each block according to the sequence
    * */
    IEnumerator ShowSequence() {
        //this bool is for locking (can't call while executing)
        coroutine = true;
        for(int i = 0; i < sequence.Length; i++) {
            // makes a block yellow for 0.5 seconds then returns it to its original.
            transform.Find(sequence[i].ToString()).GetComponent<Image>().color = Color.yellow;
            yield return new WaitForSeconds(0.5f);
            transform.Find(sequence[i].ToString()).GetComponent<Image>().color = Color.white;
        }
        coroutine = false;
    }
    /**Method Name: BlockClick()
    * Parameters: N/A
    * Returns: N/A
    * 
    * This is the main logic of the game. It counts the number of times the user 
    * has chosen correctly and resets it when wrong. 
    * */
    public void BlockClick() {
        //check if showSequence is being executed
        if (!coroutine) {
            //if the correct block is selected. Increase click num (game ends when clicknum = sequence length)
            if (ES.currentSelectedGameObject.name == sequence[clickNum].ToString()) {
                clickNum++;
            }
            //if wrong reset, decrease tries remaining, and show the sequence again
            else {
                tries--;
                clickNum = 0;
                StartCoroutine(ShowSequence());
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
        //prints the current score and the game instructions
        GUI.Label(new Rect((Screen.width / 2) - 20, (Screen.height / 2) - 220, 600, 600), "TRIES: " + tries);

        //end game if user guesses sequence correctly
        if (clickNum >= sequence.Length){
            GUI.Label((new Rect((Screen.width / 2) - 20, (Screen.height / 2) - 200, 600, 600)), "YOU PASS!");   
            //this is to avoid multiple calls of EndGame
            if (!ended) {
                //flips bit so that it wont enter this conditional again
                ended = !ended;
                //calls EndGame after 3 seconds
                Invoke("EndGame", 3);
            }
        }
        //send sms on failure
        else if(tries <= 0) {
            if (!StartGame.Practice()) {
                SendSMS.Send("Hello!");

            }
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
