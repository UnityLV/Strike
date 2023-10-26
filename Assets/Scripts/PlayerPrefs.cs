﻿
public class PlayerPrefs : UnityEngine.PlayerPrefs
{
    public static void SetBool(string key, bool value)
    {
       SetInt(key, value ? 1 : 0);
    }

    public static bool GetBool(string key)
    {
        return GetInt(key) == 1;
    }
}