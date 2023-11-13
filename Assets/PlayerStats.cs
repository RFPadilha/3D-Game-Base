using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDataPersistence
{
    /*
     * Any additional player stats should be added to "PlayerData"
     * */
    [Header("SaveData")]
    public PlayerData data;


    //Data Manipulation--------------------------------------------------------------
    public void LevelUp()
    {
        data.level++;
        data.exp = 0;
    }
    public void GainExp(int expGain)
    {
        data.exp += expGain;
    }
    public void TakeDamage(int damage)
    {
        data.currentHealth -= damage;
    }
    public void LoadData(GameData data)
    {
        this.data = data.playerData;
    }
    public void SaveData(GameData data)
    {
        data.playerData = this.data;
    }
}
