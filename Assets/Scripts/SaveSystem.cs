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
 * This file takes care of communicating with the databases of the app.
 * 
 * 1/30/2019, Andrei Fernandez: Buddy saving and loading
 * 2/8/2019, Andrei Fernandez: Choose test saving and loading
 * */
#endregion
#endregion

using UnityEngine;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    /**Method Name: AddBuddy
     * Parameters: List<BuddyData> data (contains contacts in runtime)
     * Returns: N/A
     * 
     * Saves data into a binary file.
     * */
    public static void AddBuddy(List<BuddyData> data) {
        BinaryFormatter formatter = new BinaryFormatter();
        //dictates file and directory to save it in
        string path = Application.persistentDataPath + "/buddy.data";
        //Create new or Open existing file
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

        //save in binary
        formatter.Serialize(stream, data);
        stream.Close();
    }

    /**Method Name: LoadBuddies
     * Parameters: N/A
     * Returns: List<BuddyData> buddies(contacts to be used in runtime)
     * 
     * Loads data from a binary file.
     * */
    public static List<BuddyData> LoadBuddies() {
        string path = Application.persistentDataPath + "/buddy.data";
        Debug.Log(path);
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            //translate from binary to BuddyData class
            List<BuddyData> data = formatter.Deserialize(stream) as List<BuddyData>;
            stream.Close();
            Debug.Log(data);
            return data;
        }
        //return empty list when file is missing
        else {
            Debug.LogError("Save file not found in " + path);
            return new List<BuddyData>();
        }
    }

    /**Method Name: SaveCT
     * Parameters: bool[] chosen (selected tests in runtime)
     * Returns: N/A
     * 
     * Saves the user's chosen tests
     * */
    public static void SaveCT(bool[] chosen) {
        //converts bool array to string separated by comma
        string s = string.Join(",",chosen.Select(i=>i.ToString()).ToArray());
        //saves string under the key "CT"
        PlayerPrefs.SetString("CT", s);
        Debug.Log(s);
    }

    /**Method Name: LoadCT
     * Parameters: N/A
     * Returns: bool[] chosen (selected tests in runtime)
     * 
     * Loads user's chosen tests
     * */
    public static bool[] LoadCT() {
        //Check string under the key "CT"
        string s = PlayerPrefs.GetString("CT",null);
        if (!string.IsNullOrEmpty(s)) {
            //Splits string then converts to bool.
            bool[] boolArray = s.Split(',').Select(i => Convert.ToBoolean(i)).ToArray();
            return boolArray;
        }
        else {
            return null;
        }
    }
}