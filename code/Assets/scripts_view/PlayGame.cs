using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{

    public void OnLoadLevelPressed(int levelNum)
    {
        var worldIndex = WorldsManager.instance.worldIndex;
        
        if (worldIndex != WorldMenuView.instance.worldIndex)
            return;

        if (WorldsManager.instance.CurrentWorld.IsUnlocked())
        {
            SceneManager.LoadScene(levelNum);
        }
        else
        {
            Debug.Log("Can't start game, world/level locked!");
        }
    }

}
