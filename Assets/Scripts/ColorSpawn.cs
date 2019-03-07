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
 * 3/7/2019, Carlo La Rosa: Initial Implementation and Sprite Spawning
 * 3/8/2019, Carlo La Rosa: Scoring System
 * */
#endregion
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSpawn : MonoBehaviour
{

    //int Val: serves as index for the array of sprites
    //int Type: Type = 0 pertains to the Color sprite, and Type = 1 pertains to the Word sprite, values are initialized in Unity
    public int Val = 0, Type = 0;
    //array of the sprite pictures
    public Sprite[] Sprite_Pic;


    /**Method Name: Start
    * Parameters: N/A
    * Returns: N/A
    * 
    * A built-in unity function inherted from MonoBehaviour.
    * This is activated upon start-up before Start() to set the scene.
    * Starts up the sprite spawning for the Color Game.
    * */
    public void Start()
    {
        //initialize position of the Color sprite
        if (Type == 0)
        {
            transform.position = new Vector2(0, 290);
        }
        //initialize postion of the Word sprite
        else
        {
            transform.position = new Vector2(0, 10);
        }

        //initialize the size of the sprites
        transform.localScale = new Vector2(220, 225);
        //randomizes the value of Val
        Val = Random.Range(0, Sprite_Pic.Length);
        //uses the sprite picture based on the index Val
        GetComponent<SpriteRenderer>().sprite = Sprite_Pic[Val];
    }

    /**Method Name: Update
    * Parameters: N/A
    * Returns: N/A
    * 
    * A built-in unity function inherted from MonoBehaviour.
    * This is activated once per frame.
    * */
    void Update()
    {
        
    }
}
