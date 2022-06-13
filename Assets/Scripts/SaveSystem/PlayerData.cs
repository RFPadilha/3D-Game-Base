using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData{
    public int maxHealth;
    public int currentHealth;

    public int exp;
    public int expToLevelUp;
    public int level;
    public float[] position;

    public PlayerData (PersistentPlayerStats player)
    {
        maxHealth = player.maxHealth;
        currentHealth = player.currentHealth;

        exp = player.exp;
        expToLevelUp = player.expToLevelUp;
        level = player.level;

        position = new float[3];
        position[0] = player.position[0];
        position[1] = player.position[1];
        position[2] = player.position[2];
    }
}
