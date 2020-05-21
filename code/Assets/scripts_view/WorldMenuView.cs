using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

// Copyright Sami S.

// use of any kind without a written permission 
// from the author is not allowed.

// DO NOT:
// Fork, clone, copy or use in any shape or form.

public class WorldMenuView : MonoBehaviour
{
    public static WorldMenuView instance;

    [Header("Buttons")]
    public Button moveLeftButton;
    public Button moveRightButton;
    public Button worldUnlockButton;
    public Button resetDataButton;

    [Header("Visuals")]
    public Text worldNameLabel;
    public Text worldLockedLabel;
    public Text currentLevelText;
    public string worldLockedString = "LOCKED";
    public string worldUnlockedString = "UNLOCKED";

    // local
    public List<LevelRowView> rowViews;
    public int worldIndex = 0;

    SaveData data
    {
        get => WorldsManager.instance.data;
    }




    // Init 

    void Awake()
    {
        instance = this;
    }

    void OnEnable()
    {
        worldUnlockButton?.onClick.AddListener(OnWorldUnlockPressed);
        moveLeftButton?.onClick.AddListener(OnButtonLeftPressed);
        moveRightButton?.onClick.AddListener(OnButtonRightPressed);
        resetDataButton?.onClick.AddListener(OnResetAllLevelDataPressed);
        WorldsManager.WorldChanged += OnWorldChanged;
        WorldsManager.WorldDataReady += OnWorldDataReady;
    }

    void OnDisable()
    {
        worldUnlockButton?.onClick.RemoveListener(OnWorldUnlockPressed);
        moveLeftButton?.onClick.RemoveListener(OnButtonLeftPressed);
        moveRightButton?.onClick.RemoveListener(OnButtonRightPressed);
        resetDataButton?.onClick.RemoveListener(OnResetAllLevelDataPressed);
        WorldsManager.WorldChanged -= OnWorldChanged;
        WorldsManager.WorldDataReady -= OnWorldDataReady;
    }

    void OnWorldDataReady()
    {
        Debug.Log("WorldMenuView - OnWorldDataReady");
        worldIndex = Mathf.Clamp(WorldsManager.instance.worldIndex, 0, int.MaxValue);

        GetRowViews();
        ShowCurrentWorld();
    }




    // Event

    void OnWorldChanged()
    {
        ShowCurrentWorld();
    }




    // World levels view

    void ShowCurrentWorld()
    {
        // World name        
        worldNameLabel.text = data.worlds[worldIndex].worldName;

        // Level name
        var level = data.worlds[worldIndex].levels[0];
        ShowLevelNameText(level);

        // Level list
        UpdateLevelViews();

        // Unlock button
        worldUnlockButton.interactable = data.worlds[worldIndex].IsUnlocked() == false;
    }

    public void ShowLevelNameText(LevelData levelData)
    {
        if (!WorldsManager.instance.IsLevelWorldLocked(levelData))
        {
            currentLevelText.text = "SELECTED: " + levelData.levelName;
            WorldsManager.instance.levelIndex = WorldsManager.instance.GetIndexOfLevel(levelData);
        }
        else
        {
            currentLevelText.text = "";
        }
    }

    void UpdateLevelViews()
    {
        // Disable all level views
        foreach (var r in rowViews)
        {
            r.gameObject.SetActive(false);
        }

        // Set world locked status text
        var str = data.worlds[worldIndex].locked ? worldLockedString : worldUnlockedString;
        worldLockedLabel.text = str;


        // Set level views
        for (int i = 0; i < data.worlds[worldIndex].levels.Count; i++)
        {
            if (i >= rowViews.Count)
                break;

            // Fill data
            var levelData = data.worlds[worldIndex].levels[i];

            rowViews[i].UpdateView(levelData, data.worlds[worldIndex].locked);

            rowViews[i].gameObject.SetActive(true);
        }
    }




    // UI button handlers

    public void OnButtonLeftPressed()
    {
        if (worldIndex > 0)
        {
            worldIndex--;
            WorldsManager.instance.TrySetCurrentWorldIndex(worldIndex);
            ShowCurrentWorld();
        }
    }

    public void OnButtonRightPressed()
    {
        if (worldIndex < Worlds.Data.worlds.Count - 1)
        {
            worldIndex++;
            WorldsManager.instance.TrySetCurrentWorldIndex(worldIndex);
            ShowCurrentWorld();
        }
    }

    public void OnWorldUnlockPressed()
    {
        WorldsManager.instance.UnlockWorld(worldIndex);
        WorldsManager.instance.TrySetCurrentWorldIndex(worldIndex);
        ShowCurrentWorld();
    }

    public void OnResetAllLevelDataPressed()
    {
        worldIndex = 0;
        WorldsManager.instance.ResetAllData();
        WorldsManager.instance.TrySetCurrentWorldIndex(worldIndex);
        ShowCurrentWorld();
    }



    // Helpers

    void GetRowViews()
    {
        LevelRowView[] rows = this.GetComponentsInChildren<LevelRowView>();

        foreach (LevelRowView r in rows)
        {
            rowViews.Add(r);
        }
    }


}

