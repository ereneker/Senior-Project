using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManagement
{
    public static string userID;
    public static string score;

    public static bool isLoggedIn { get { return userID != null; } }

    public static void loggingOut()
    {
        userID = null;
    }
}
