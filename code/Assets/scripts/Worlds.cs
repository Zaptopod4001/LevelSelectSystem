using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

// Copyright Sami S.

// use of any kind without a written permission 
// from the author is not allowed.

// DO NOT:
// Fork, clone, copy or use in any shape or form.



// Runtime Reference to ScriptableObject containing levels data

public class Worlds : MonoBehaviour
{

    public static Worlds instance;

    [Header("Settings")]
    [SerializeField] SaveData data = new SaveData();

    [Header("Assign")]
    public GameData gameData;


    // Properties 
    public static SaveData Data { get => instance.data; set => instance.data = value; }

    // local
    const string saveName = "savedata";



    // Init 

    void Awake()
    {
        instance = this;
    }



    // Main

    void Update()
    {
        // Testing only
        {
            if (Input.GetKeyDown(KeyCode.F12))
                ClearSaveData();

            if (Input.GetKeyDown(KeyCode.F5))
                SaveWorldData();

            if (Input.GetKeyDown(KeyCode.F9))
                LoadWorldData();
        }
    }



    // Save load

    public void ClearSaveData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("ClearSaveData - done");
    }

    public void LoadWorldData()
    {
        var json = PlayerPrefs.GetString(saveName, "");

        if (string.IsNullOrEmpty(json))
        {
            Debug.Log("Load default data");
            data = gameData.GetSaveDataClone();
        }
        else
        {
            Debug.Log("Load saved data");
            data = JsonUtility.FromJson<SaveData>(json);
        }
    }

    public void SaveWorldData()
    {
        var json = JsonUtility.ToJson(data, true);

        Debug.Log("Worlds - SaveWorldData");
        PlayerPrefs.SetString(saveName, json);
    }

}