using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuddyController : MonoBehaviour {
    private List<BuddyData> buddies;
    public InputField buddyName;
    public InputField buddyNumber;
    public GameObject buddyPrefab;
    public GameObject container;

    private void Awake() {
        buddies = SaveSystem.LoadBuddies();
    }
    // Update is called once per frame
    private void Start() {
        UpdateList();
    }
    public void getInput(){
        BuddyData newBuddy = new BuddyData(buddyName.text,buddyNumber.text);
        buddies.Add(newBuddy);
        SaveSystem.AddBuddy(buddies);
        foreach (BuddyData buddy in buddies) {
            Debug.Log(buddy);
        }
	}

    private void UpdateList() {
        for (int x = 1; x < buddies.Count; x++) {
            GameObject buddy = Instantiate(buddyPrefab) as GameObject;
            buddy.transform.SetParent(this.transform);
            buddy.name = "buddy" + x;

            buddy.GetComponent<RectTransform>().anchorMin = new Vector2((float)0.1, ((float)1280 / (buddies.Count + 1) * -x));
            buddy.GetComponent<RectTransform>().anchorMax = new Vector2((float)0.9, ((float)1280 / (buddies.Count + 1) * -x));

            buddy.GetComponentInChildren<Text>().text = buddies[x-1].ToString();
        }
    }


}
