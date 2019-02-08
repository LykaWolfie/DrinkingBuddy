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
 * This file dictates the class variable for easier referencing
 * 
 * 1/30/2019, Andrei Fernandez: Initial implementation
 * 2/6/2019, Andrei Fernandez: Override ToString
 * */
#endregion
#endregion

using UnityEngine;
using System.Collections;

[System.Serializable]
public class BuddyData {

    string name;
    string number;

    /**Method Name: BuddyData (class constructor)
     * Parameters: string name
     *             string number
     * Returns: N/A
     * 
     * Enables initalization of BuddyData object
     * */
    public BuddyData(string name, string number) {
        this.name = name;
        this.number = number;
    }

    /**Method Name: ToString (override)
     * Parameters: N/A
     * Returns: String
     * 
     * Transforms data into string
     * */
    public override string ToString() {
        return name + "\n" + number + "\n";
    }
}
