using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

// Copyright Sami S.

// use of any kind without a written permission 
// from the author is not allowed.

// DO NOT:
// Fork, clone, copy or use in any shape or form.

public class WorldsManager : MonoBehaviour
{

    public static WorldsManager instance;

    public static event Action WorldDataReady;
    public static event Action WorldChanged;

    [Header("Debug")]
    public int levelIndex;
    public int worldIndex;

    // Local helpers
    bool removed = false;
    bool init = false;


    // Properties 

    public SaveData data
    {
        get => Worlds.Data;
    }

    public WorldData CurrentWorld
    {
        get => Worlds.Data.worlds[worldIndex];
        set => Worlds.Data.worlds[worldIndex] = value;
    }

    public LevelData CurrentLevel
    {
        get
        {
            levelIndex = Mathf.Clamp(levelIndex, 0, int.MaxValue);
            worldIndex = Mathf.Clamp(worldIndex, 0, int.MaxValue);

            return Worlds.Data.worlds[worldIndex].levels[levelIndex];
        }
    }



    // Init

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        if (this != instance)
        {
            DestroyImmediate(this.gameObject);
            removed = true;
        }
    }

    void OnEnable()
    {
        if (removed)
            return;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        if (removed)
            return;

        SceneManager.sceneLoaded -= OnSceneLoaded;
        SaveData();
    }

    void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (removed)
            return;

        Debug.Log("OnSceneLoaded");

        if (!init)
        {
            init = true;
            LoadData();
        }

        // Let data users know
        WorldDataReady?.Invoke();
    }




    // World

    public void UnlockWorld(int num)
    {
        data.worlds[num].UnlockWorld();
    }

    public void TrySetCurrentWorldIndex(int worldIndex)
    {
        if (data.worlds[worldIndex].locked == false)
        {
            this.worldIndex = worldIndex;
        }
    }

    public void ResetAllData()
    {
        Debug.Log("ResetAllLevelData");

        Worlds.instance.ClearSaveData();
        Worlds.instance.LoadWorldData();

        worldIndex = 0;
        levelIndex = 0;
    }




    // Level

    public void CompleteCurrentLevel()
    {
        CompleteLevel(data.worlds[worldIndex].levels[levelIndex]);
    }

    void CompleteLevel(LevelData levelData)
    {
        levelData.completed = true;
        Debug.Log("Completed level:" + levelData.levelName);

        WorldChanged?.Invoke();
    }

    public bool IsLevelWorldLocked(LevelData levelData)
    {
        foreach (var w in data.worlds)
        {
            foreach (var l in w.levels)
            {
                if (l == levelData) return w.locked;
            }
        }

        return false;
    }




    // Helpers

    public int GetIndexOfLevel(LevelData levelData)
    {
        foreach (var w in data.worlds)
        {
            foreach (var l in w.levels)
            {
                if (l.levelName == levelData.levelName)
                {
                    return w.levels.IndexOf(l);
                }
            }
        }

        return -1;
    }



    // Persist data

    void LoadData()
    {
        Worlds.instance.LoadWorldData();
    }

    void SaveData()
    {
        Worlds.instance.SaveWorldData();
    }


}

