using System.Collections;
using UnityEngine;

public class Swipe : MonoBehaviour {

    public Camera main;
    public int frames; //number of "animation" frames, suggested: 10-25
    public float threshold; //swipe distance needed before calling function
    float startTouch;

    // Update is called once per frame
    void Update () {
        //This part is completely for testing functionalities on a computer
        //What it does mirrors mobile input
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
        
        //This is for mobile input
        //Check first if the screen has been touch
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

    //An IEnumerator enables "yield" which can be used to make the script wait for something
    //This function adjusts the camera to simulate switching between screens
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
