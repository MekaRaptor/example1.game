using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu1 : MonoBehaviour
{
    public string firstLevel;
    public string LevelSelect;

    public string[] levelNames;

    public int startingLives;
    public void PlayGame()
    {
        SceneManager.LoadScene(firstLevel);

        for (int i = 0; i < levelNames.Length; i++)
        {
            PlayerPrefs.SetInt(levelNames[i], 0);
        }
        PlayerPrefs.SetInt("CoinCount", 0);
        PlayerPrefs.SetInt("PlayerLives", startingLives);


    }
    public void ContinueGame()
    {
        SceneManager.LoadScene(LevelSelect);
    }
    public void QuitGame()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
