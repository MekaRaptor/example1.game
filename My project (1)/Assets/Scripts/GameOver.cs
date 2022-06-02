using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public string levelSelect;
    public string mainMenu;

    private HealthManager theHealthManager;
    void Start()
    {
        theHealthManager = FindObjectOfType<HealthManager>();
    }

    
    
    public void Restart()
    {
        PlayerPrefs.SetInt("CoinCount", 0);
        PlayerPrefs.SetInt("PlayerLives", theHealthManager.startingLives);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LevelSelect()
    {
        PlayerPrefs.SetInt("CoinCount", 0);
        PlayerPrefs.SetInt("PlayerLives", theHealthManager.startingLives);

        SceneManager.LoadScene(levelSelect);
    }
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }



}
