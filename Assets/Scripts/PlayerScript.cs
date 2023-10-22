using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class PlayerScript : MonoBehaviour, IDataPersistence
{
    /*
     * Any additional player stats should also be added to "PlayerData" and "PersistentPlayerStats" scripts for adequate save manipulation
     * */
    public PlayerData data;


    // Start is called before the first frame update
    void Awake()
    {
        /*
        data = PersistentPlayerStats.instance.data;
        

        maxHealth = data.maxHealth;
        currentHealth = data.currentHealth;

        exp = data.exp;
        expToLevelUp = data.expToLevelUp;
        level = data.level;
        transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
        */
}

    // Update is called once per frame
    void Update()
    {
        
    }
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

    public void SaveData(ref GameData data)
    {
        data.playerData = this.data;
    }
}
