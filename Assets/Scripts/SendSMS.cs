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
 * Created by rmdwirizki
 * Retrieved from: https://gist.github.com/rmdwirizki/87f9e68c7ef6ef809a777eb25f12c3b2
 * Modified by the Drinking Buddy Group for the Party People
 * This file gives the app SMS capabilities and has been modified to suit the project.
 * 
 * 2/22/2019, Andrei Fernandez: Changed to a static class
 * */
#endregion
#endregion
using UnityEngine;
using System.Collections.Generic;

public static class SendSMS 
{
    static AndroidJavaObject currentActivity;
    private static List<BuddyData> buddies;
    /**Method Name: Send
    * Parameters: string phone (number of receiver)
    * Returns: N/A
    * 
    * Checks if the platform is an Android
    * */
    public static void Send(string phone)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            RunAndroidUiThread();
        }
    }

    public static void setBuddies(List<BuddyData> update) {
        buddies = update;
    }

    /**Method Name: RunAndroidUiThread
    * Parameters: N/A
    * Returns: N/A
    * 
    * Sets up the Environment for SendProcess then calls it
    * */
    static void RunAndroidUiThread()
    {
        AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(SendProcess));
    }

    /**Method Name: SendProcess
    * Parameters: N/A
    * Returns: N/A
    * 
    * Sends an SMS, and notifies the user if it sends or not
    * */
    static void SendProcess()
    {
        Debug.Log("Running on UI thread");
        AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
        
        // SMS Information
        foreach(BuddyData buddy in buddies) {
            if (buddy.isActive) {
                string phone = buddy.getNumber();
                string text = "Hello " + buddy.getName() + "! YOUR FRIEND IS DRUNK! Please send him/her home!";
                string alert;

                try {
                    // Actual sending of SMS

                    AndroidJavaClass SMSManagerClass = new AndroidJavaClass("android.telephony.SmsManager");
                    AndroidJavaObject SMSManagerObject = SMSManagerClass.CallStatic<AndroidJavaObject>("getDefault");
                    SMSManagerObject.Call("sendTextMessage", phone, null, text, null, null);

                    alert = "Message sent successfully.";
                }
                catch (System.Exception e) {
                    Debug.Log("Error : " + e.StackTrace.ToString());

                    alert = "Error has been Occurred. Fail to send message.";
                }

                // Show Toast or Alert message

                AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
                AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", alert);
                AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
                toast.Call("show");
            }
        }
    }
}