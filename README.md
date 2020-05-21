# Level Select System (Unity / C#)

## What is it?

An example how to setup a level selection system, along with saving and loading of unlocked worlds and solved levels status.

![Level Select System image](/doc/level_select_system.png)

# Features
* Show game worlds (3 different ones in this demo)
* Show selected world's levels
* Show selected levels status (locked, not played, solved)
* World and level data stored in scriptable object
* Modified level info stored in serializable class
* Save/load World/level state data

# How to use
Open menu scene and press Play. Press "unlock world" to unlock a world (there are no conditions for unlocking in this demo). Press "play game" to enter/exit "game" scene to solve a level. 

# Classes

## GameData.cs
Scriptable Object container for clean game world/level SaveData.

## SaveData.cs
Serializable class containing world/level save data.

##  Worlds.cs
Worlds Manager and other classes access scriptable object's data via this class.

## WorldsManager.cs
Handles unlocking of worlds and managing of selected world and level.

## WorldMenuView.cs
Handles drawing, updating and input related to level list and level menu buttons.

## LevelRowView.cs
Handles drawing, updating and input related to level row view.


# About
I created this level select menu system some years ago as a learning experience.

# Copyright
Code created by Sami S. use of any kind without a written permission from the author is not allowed. But feel free to take a look.
