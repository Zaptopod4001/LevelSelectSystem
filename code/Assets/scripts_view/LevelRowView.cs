using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelRowView : MonoBehaviour
{

    [Header("Assign")]
    public Button levelButton;
    public Text levelNameLabel;
    public Image levelImage;
    public Image completedImage;
    public Sprite levelLockedSprite;
    public Sprite levelCompletedSprite;
    public Sprite levelNotCompletedSprite;

    // locals
    LevelData leveData;


    // Init

    void OnEnable()
    {
        levelButton?.onClick.AddListener(OnLevelButtonPressed);
    }

    void OnDisable()
    {
        levelButton?.onClick.RemoveListener(OnLevelButtonPressed);
    }



    // UI button handler

    public void OnLevelButtonPressed()
    {
        WorldMenuView.instance.ShowLevelNameText(leveData);
    }



    // Update row view

    public void UpdateView(LevelData data, bool worldLocked)
    {
        // store ref
        this.leveData = data;


        // heading
        levelNameLabel.text = data.levelName;

        // if world locked only show lock
        if (worldLocked)
        {
            levelImage.sprite = this.levelLockedSprite;
            completedImage.gameObject.SetActive(false);
            return;
        }


        // If world not locked
        completedImage.gameObject.SetActive(true);

        // Level image from database
        // don't use serialized sprite id from save data
        levelImage.sprite = Worlds.instance.gameData.GetLevelSprite(WorldsManager.instance.worldIndex, WorldsManager.instance.levelIndex);

        // Completion symbol
        completedImage.sprite = data.completed ? levelCompletedSprite : levelNotCompletedSprite;
    }

}
