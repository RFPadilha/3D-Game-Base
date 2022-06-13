using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    /*
     * Any additional player stats should also be added to "PlayerData" and "PersistentPlayerStats" scripts for adequate save manipulation
     * */
    PersistentPlayerStats persistentStats;
    public int maxHealth;
    public int currentHealth;

    public int exp;
    public int expToLevelUp;
    public int level;


    // Start is called before the first frame update
    void Start()
    {
        persistentStats = FindObjectOfType<PersistentPlayerStats>();
        

        maxHealth = persistentStats.maxHealth;
        currentHealth = persistentStats.currentHealth;

        exp = persistentStats.exp;
        expToLevelUp = persistentStats.expToLevelUp;
        level = persistentStats.level;
        transform.position = new Vector3(persistentStats.position[0], persistentStats.position[1], persistentStats.position[2]);
}

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelUp()
    {
        level++;
        exp = 0;
    }
    public void GainExp(int expGain)
    {
        exp += expGain;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
