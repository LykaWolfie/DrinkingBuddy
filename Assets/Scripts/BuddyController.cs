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
 * Created: 1/30/2019 by Drinking Buddy Group for the Party People.
 * This file acts as a Controller which handles input and feedback of
 * BuddyData(a user's contact) objects.
 * 
 * 1/30/2019, Andrei Fernandez: Added getInput and Start
 * 2/5/2019, Andrei Fernandez: Moved Start content to Awake
 * 2/6/2019, Andrei Fernandez: Added UpdateList
 * */
#endregion
#endregion

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuddyController : MonoBehaviour {

    private List<BuddyData> buddies;
    public InputField buddyName;
    public InputField buddyNumber;
    public GameObject buddyPrefab; //An Image(bg) with a child Text(content)
    public GameObject container;

    /**Method Name: Awake
     * Parameters: N/A
     * Returns: N/A
     * 
     * A built-in unity function inherted from MonoBehaviour.
     * This is activated upon start-up before Start() to set the scene.
     * Loads saved contacts.
     * */
    private void Awake() {
        buddies = SaveSystem.LoadBuddies();
    }

    /**Method Name: Start
     * Parameters: N/A
     * Returns: N/A
     * 
     * A built-in unity function inherted from MonoBehaviour.
     * This is activated upon start-up to set the scene.
     * Calls UpdateList.
     * */
    private void Start() {
        UpdateList();
    }

    /**Method Name: getInput
     * Parameters: N/A
     * Returns: N/A
     * 
     *Takes input from the user and creates a new BuddyData and adds it to the list.
     * */
    public void getInput(){
        BuddyData newBuddy = new BuddyData(buddyName.text,buddyNumber.text);
        buddies.Add(newBuddy);

        //Automatically saves changes to the file
        SaveSystem.AddBuddy(buddies);
        UpdateList();
	}
    /**Method Name: UpdateList
     * Parameters: N/A
     * Returns: N/A
     * 
     * This is used to change the display of the BuddyData list.
     * */
    private void UpdateList() {
        //for dynamic sizing of the screen (semi-hard coded)
        float height = Screen.height;
        if (buddies.Count > 10) {
            height += 110 * (buddies.Count - 10);
        }
        container.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width,height); 

        //this creates objects equal to the number of BuddyDatas which houses the information
        for (int x = 0; x < buddies.Count; x++) {
            GameObject buddy = Instantiate(buddyPrefab) as GameObject;
            buddy.name = "buddy" + x;
            //Anchors the objects to the screen to avoid displacement
            buddy.transform.SetParent(container.transform);
            //Sets the position of the object relative to the anchor(Top-center)
            buddy.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,-(x*110)-100);
            buddy.GetComponentInChildren<Text>().text = buddies[x].ToString();
        }
    }
}
