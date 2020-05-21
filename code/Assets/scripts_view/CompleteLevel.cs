using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    
    void Start()
    {
        WorldsManager.instance.CompleteCurrentLevel();
    }

}
