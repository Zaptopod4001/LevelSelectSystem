# Level Select System (Unity / C#)

## What is it?

An example how to setup a level selection system, along with saving and loading of unlocked worlds and solved levels status.

![Level Select System image](/doc/level_select_system.png)

# Features
* Show Game Worlds
* Show selected world levels
* Show selected levels status (locked, not played, solved)
* Level data stored in scriptable object
* Modified level info stored in serializable classes
* Save/load of level data

# How to use
Open menu scene and press play. Press play to enter/exit "game" scene to solve a level. Press unlock world to unlock a world (there are no conditions for unlocking in this demo).


# Classes

## GameData.cs
ScriptableObject container for clean game world/level SaveData.

## SaveData.cs
Serializable class containing world/level save data

##  Worlds.cs
Access scriptable object data from this class asset.

## WorldsManager.cs
Handles unlocking of worlds and managing of selected world and level.

## WorldMenuView.cs
Handles drawing, updating and input related of level list and level menu buttons.

## LevelRowView.cs
Handles drawing, updating and input related to level row view.


# About
I created this level select menu system some years ago, as a learning experience.

# Copyright
Code created by Sami S. use of any kind without a written permission from the author is not allowed. But feel free to take a look.