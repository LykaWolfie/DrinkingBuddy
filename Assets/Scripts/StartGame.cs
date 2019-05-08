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
 * Created: 2/19/2019 by Drinking Buddy Group for the Party People.
 * This file links the starting scene to the test scene.
 * 
 * 2/19/2019, Carlo La Rosa: Implementation and Completion
 * 3/6/2019, Andrei Fernandez: Added overload function for PracticeTest and TakeTest
 * */
#endregion
#endregion

using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class StartGame {

    static List<int> sceneOrder = new List<int>();
    private static System.Random rng = new System.Random();
    static bool isPractice;

    /**Method Name: ChangeToGameScene
     * Parameters: int index
     * Returns: N/A
     * 
     *This function is for initiating practiceTest. It takes an integer as the index of the next scene to be loaded.
     * */

    public static void ChangeToGameScene(int index) {
        isPractice = true;

        //adds the scene clicked then the main screen
        sceneOrder = new List<int>();
        sceneOrder.Add(index);
        sceneOrder.Add(0);
        
        //Loads next (which is the test clicked)
        LoadNext();
    }

    /**Method Name: ChangeToGameScene
     * Parameters: bool[] activeTest
     * Returns: N/A
     * 
     *This function is for initiating takeTest. It checks for all active tests indicated in the chooseTest, and adds
     *adds them to the scenes to be loaded
     * */
    public static void ChangeToGameScene(bool[] activeTest) {
        isPractice = false;
        sceneOrder = new List<int>();
        for (int i = 0; i < activeTest.Length; i++) {
            if (activeTest[i]) {
                //add to the list only if its respective flag is true
                sceneOrder.Add(i + 1);
            }
        }
        //simple randomization of scenes
        List<int> shuffledScenes = sceneOrder.OrderBy(a => rng.Next()).ToList();
        sceneOrder = new List<int>();//clear List

        for(int i = 0; i < shuffledScenes.Count; i++) {
            //Adds a the timer scene before each game
            sceneOrder.Add(5);
            sceneOrder.Add(shuffledScenes[i]);
        }

        //add main screen at the end
        sceneOrder.Add(0);
        LoadNext();
    }

    /**Method Name: LoadNext
     * Parameters: N/A
     * Returns: N/A
     * 
     *This function is used for switching to the next scene
     * */
    public static void LoadNext() {
        Debug.Log("Next Scene:" + sceneOrder[0]);

        //loads next scene and removes it from the list
        SceneManager.LoadScene(sceneOrder[0]);
        sceneOrder.Remove(sceneOrder[0]);

    }
    

    /**Method Name: Practice
     * Parameters: N/A
     * Returns: bool isPractice (indicates if it's practiceTest or takeTest)
     * 
     *Returns the current state of the practice flag
     * */
    public static bool Practice() {
        return isPractice;
    }
}