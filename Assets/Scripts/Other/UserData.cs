using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    public static int GetLevel()
    {
        return PlayerPrefs.GetInt("Level");
    }

    public static void SaveLevel(int level)
    {
        PlayerPrefs.SetInt("Level", level);
    }
}
