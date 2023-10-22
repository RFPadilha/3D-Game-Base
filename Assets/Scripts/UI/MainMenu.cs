using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuHolder;
    public GameObject optionsMenuHolder;

    //PersistentPlayerStats playerStats;
    private void Start()
    {
        //playerStats = FindObjectOfType<PersistentPlayerStats>();
    }
    public void Continue()
    {
        //LoadGame();
    }
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadGame()
    {
        //playerStats.data = SaveSystem.LoadPlayer();
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
