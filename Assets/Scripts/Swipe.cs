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
 * Created: 2/2/2019 by Drinking Buddy Group for the Party People.
 * This file enables mobile controls and screen switching
 * 
 * 2/2/2019, Andrei Fernandez: Added Update, and SlideCamera
 * 2/5/2019, Andrei Fernandez: Improved SlideCamera behaviour
 * to implement highlighting system
 * */
#endregion
#endregion

using System.Collections;
using UnityEngine;

public class Swipe : MonoBehaviour {

    public Camera main;
    public int frames; //number of "animation" frames, suggested: 10-25
    public float threshold; //swipe distance needed before calling function
    float startTouch;

    /**Method Name: Update
     * Parameters: N/A
     * Returns: N/A
     * 
     * A built-in unity function inherted from MonoBehaviour.
     * This is called every few frames.
     * Takes all inputs.
     * */
    void Update () {
        //This part is completely for testing functionalities on a computer(mirrors mobile)
        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("touch");
            startTouch = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0)) {
            float delta = startTouch - Input.mousePosition.x;
            Debug.Log(delta);
            if (Mathf.Abs(delta) >= threshold) {
                StartCoroutine(slideCamera(delta));
            }
        }
        #endregion
        
        //Mobile input
        //Check first if the screen has been touched
        if (Input.touchCount>0) {
            //Upon touching, store the x-coordinate of the touch
            if (Input.touches[0].phase == TouchPhase.Began) {
                 startTouch = Input.touches[0].position.x;
            }
            //Upon lifting, calculate x-distance traveled 
            else if (Input.touches[0].phase == TouchPhase.Ended) {
                float delta = startTouch - Input.touches[0].position.x;
                //Check if swipe passes threshold distance
                if (Mathf.Abs(delta) >= threshold) {
                    StartCoroutine(slideCamera(delta));
                }
            }
        }
	}

    /**Method Name: slideCamera
     * Parameters: float delta (distance of swipe)
     * Returns: IEnumerator(unity built-in class)
     * 
     * Adjusts the camera to switch between screens.
     * IEnumerator enables waiting
     * */
    IEnumerator slideCamera(float delta) {
        //Check if positive and if the camera is still within bounds (for left swipe)
        if (delta > 0 && main.transform.position.x != 800) {
            //adjust the camera position in small increments to simulate sliding
            for (int i=0;i<frames;i++) {
                //800 screen width, every frame is 0.005 seconds
                main.transform.position += new Vector3(800 / frames, 0, 0); 
                yield return new WaitForSeconds((float)0.005);
            }
        }
        //for right swipe
        else if (delta < 0 && main.transform.position.x != -800) {
            for (int i = 0; i < frames; i++) {
                main.transform.position += new Vector3(-800 / frames, 0, 0);
                yield return new WaitForSeconds((float)0.005);
            }
        }
    }
}
