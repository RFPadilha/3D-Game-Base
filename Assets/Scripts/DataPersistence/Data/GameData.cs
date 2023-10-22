using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public PlayerData playerData;
    public SerializableDictionary<string, bool> collectedObjects;

    //initial values when theres no data to load
    public GameData()
    {
        this.playerData = new PlayerData();
        collectedObjects = new SerializableDictionary<string, bool>();
    }
}
