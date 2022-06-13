using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuHolder;
    public GameObject optionsMenuHolder;

    PersistentPlayerStats playerStats;
    private void Start()
    {
        playerStats = FindObjectOfType<PersistentPlayerStats>();
    }
    public void Continue()
    {
        LoadGame();
    }
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        playerStats.currentHealth = data.currentHealth;
        playerStats.maxHealth = data.maxHealth;
        playerStats.exp = data.exp;
        playerStats.expToLevelUp = data.expToLevelUp;
        playerStats.level = data.level;
        playerStats.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OptionsMenu()
    {
        optionsMenuHolder.SetActive(true);
        mainMenuHolder.SetActive(false);
    }
    public void ReturnFromOptionsMenu()
    {
        optionsMenuHolder.SetActive(false);
        mainMenuHolder.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application ceased execution.");
    }
}
