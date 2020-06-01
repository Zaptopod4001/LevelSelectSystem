using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Copyright Sami S.

// use of any kind without a written permission 
// from the author is not allowed.

// DO NOT:
// Fork, clone, copy or use in any shape or form.


public class CompleteLevel : MonoBehaviour
{
    
    void Start()
    {
        WorldsManager.instance.CompleteCurrentLevel();
    }

}
