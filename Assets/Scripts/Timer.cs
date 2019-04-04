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
 * Created: 4/4/2019 by Drinking Buddy Group for the Party People.
 * This is the script for simulating the countdown found in between games
 * 
 * 4/4/2019: Andrei Fernandez, Implemented the variable text
 * */
#endregion
#endregion

using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    public Text countdown;

    /**Method Name: Updae
    * Parameters: N/A
    * Returns: N/A
    * 
    * A built-in unity function inherted from MonoBehaviour.
    * This is called once per frame.
    * Changes the text according to the current value of the float time.
    * */
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0) {
            StartGame.LoadNext();
            // divided by 60 for the minutes, modulo for the seconds
            countdown.text = Mathf.Floor(time / 60).ToString("00") + ":" + Mathf.Floor(time % 60).ToString("00");
        }
        
    }
}
