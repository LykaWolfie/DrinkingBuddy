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

public static class  StartGame{

    static List<int> sceneOrder = new List<int>();
    private static System.Random rng = new System.Random();
    static bool isPractice;

    /**Method Name: ChangeToGameScene
     * Parameters: int index
     * Returns: N/A
     * 
     *This function is for initiating practiceTest. It takes an integer as the index of the next scene to be loaded.
     * */

    public static void ChangeToGameScene(int index){

        isPractice = true;
        sceneOrder.Add(index);
        sceneOrder.Add(0);
        //SceneManager manages the game scenes at run-time. LoadScene loads the scene name given as input.
        LoadNext();
    }

    /**Method Name: ChangeToGameScene (overload)
     * Parameters: string game
     * Returns: N/A
     * 
     *This function takes the name of the scene as string input
     *and switches to that scene upon activation.
     * */
    public static void ChangeToGameScene(bool[] activeTest) {
        isPractice = false;
        for(int i=0;i<activeTest.Length; i++){
            if (activeTest[i]) {
                sceneOrder.Add(i + 1);
            }
        }
        List<int> shuffledScenes = sceneOrder.OrderBy(a => rng.Next()).ToList();
        sceneOrder = shuffledScenes;
        sceneOrder.Add(0);
        LoadNext();
    }

    public static void LoadNext() {
        SceneManager.LoadScene(sceneOrder[0]);
        sceneOrder.Remove(sceneOrder[0]);
    }

    public static bool Practice() {
        return isPractice;
    }
}
