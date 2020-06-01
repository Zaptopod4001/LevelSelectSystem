using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Copyright Sami S.

// use of any kind without a written permission 
// from the author is not allowed.

// DO NOT:
// Fork, clone, copy or use in any shape or form.


// used by ingame scene

public class LevelInfoShow : MonoBehaviour
{

    [Header("Settings")]
    Text label;
    string worldName = "-";
    string levelName = "-";


    void OnEnable()
    {
        label = this.GetComponent<Text>();
    }


    void Start()
    {
        SetText();
    }

    void SetText()
    {
        if (WorldsManager.instance.CurrentWorld == null)
            return;

        worldName = WorldsManager.instance.CurrentWorld.worldName;
        levelName = WorldsManager.instance.CurrentLevel.levelName;

        // Set text
        label.text = "WORLD: " + worldName + "\n LEVEL: " + levelName;
    }

}
