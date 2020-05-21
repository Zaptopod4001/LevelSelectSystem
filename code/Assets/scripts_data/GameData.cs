using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameData", fileName = "GameData")]
public class GameData : ScriptableObject
{
    public SaveData saveData;

    public Sprite GetLevelSprite(int worldIndex, int levelIndex)
    {
        return saveData.worlds[worldIndex].levels[levelIndex].levelImage;
    }

    public SaveData GetSaveDataClone()
    {
        var json = JsonUtility.ToJson(saveData);
        var clone = JsonUtility.FromJson<SaveData>(json);
        return clone;
    }
}
