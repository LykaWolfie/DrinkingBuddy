using UnityEngine;
using System.Collections;

//this is just a class variable for easier referencing.
//It has the name and number attributes(self explanatory)
[System.Serializable]
public class BuddyData {

    string name;
    string number;
    //Class constructor. Upon creating this variable you may specify the attributes already
    //Usage: BuddyData variableName = new BuddyData(name,number);
    public BuddyData(string name, string number) {
        this.name = name;
        this.number = number;
    }

    //string form of the BuddyData Class
    public override string ToString() {
        return name + "\n" + number + "\n";
    }
}
