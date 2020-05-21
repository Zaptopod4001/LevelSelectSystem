using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;


[System.Serializable]
public class SaveData
{
    public List<WorldData> worlds;
}


[System.Serializable]
public class WorldData
{
    [Header("Settings")]
    public string worldName;

    [Header("Levels")]
    public List<LevelData> levels;

    // settings
    public bool locked = true;

    public bool IsUnlocked()
    {
        return this.locked == false;
    }

    public void UnlockWorld()
    {
        Debug.Log("World unlocked: " + worldName);
        this.locked = false;
    }

}


[System.Serializable]
public class LevelData
{
    public Sprite levelImage;
    public string levelName = "Level";

    [Header("Changing")]
    public bool completed;

}
