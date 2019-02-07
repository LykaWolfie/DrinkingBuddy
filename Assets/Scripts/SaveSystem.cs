using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

//Accesses databases
public static class SaveSystem {

    //Saves the list of buddies into a file in binary
    //Parameter: List of BuddyData objects
    public static void AddBuddy(List<BuddyData> data) {
        BinaryFormatter formatter = new BinaryFormatter();
        //dictates file and directory to save it in
        string path = Application.persistentDataPath + "/buddy.data";
        //Create new or Open existing file
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

        //save in binary
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("save");
    }

    //Returns a list of buddies to be used on runtime
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



}