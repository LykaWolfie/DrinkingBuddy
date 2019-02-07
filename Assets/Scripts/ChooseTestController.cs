using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChooseTestController : MonoBehaviour {
    //size determines number of buttons, chosen determines if a test is activated, CTmode is on/off
    public int size;
    private bool[] chosen;
    private bool CTmode;
    public EventSystem ES;
    
    //initializing array size on startup
    private void Start() {
        chosen = new bool[size];
    }

    //When user clicks a button, this function is called.
    //It determines which button is clicked and activates/deactivates respective test.
    public void updateTest() {
        //gets name of button which is a number
        int testNumber = int.Parse(ES.currentSelectedGameObject.name);
        
        //Flips bool, testNumber-1 for indexing
        chosen[testNumber - 1] = !chosen[testNumber - 1];
        Debug.Log(testNumber);
        Debug.Log(chosen[testNumber-1]);
    }

    //this is only called by the Choose Test button
    public void Activate() {
        CTmode = !CTmode;
        if (CTmode) {
            ES.currentSelectedGameObject.GetComponentInChildren<Text>().text = "Cancel";
            //display OK
        }
        else {
            ES.currentSelectedGameObject.GetComponentInChildren<Text>().text = "Choose Test";
        }
    }

}
