using UnityEngine;
using System.Collections;
using UnityEngine.UI;


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
