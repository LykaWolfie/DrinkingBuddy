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
 * */
#endregion
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    /**Method Name: ChangeToGameScene
     * Parameters: string game
     * Returns: N/A
     * 
     *This function takes the name of the scene as string input
     *and switches to that scene upon activation.
     * */
    public void ChangeToGameScene(string game)
    {
        //SceneManager manages the game scenes at run-time. LoadScene loads the scene name given as input.
        SceneManager.LoadScene(game);
    }
}
