using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd1 : MonoBehaviour
{
    public string levelToLoad;
    public string levelToUnlock;

    public HealthManager thehealthManager;

   
    void Start()
    {
        thehealthManager = FindObjectOfType<HealthManager>();
        
    }

    
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine("LevelEndCo");
            
            
            PlayerPrefs.SetInt("PlayerLives", thehealthManager.currentLives);

        }
    }
    public IEnumerator LevelEndCo() {
        
        
            PlayerPrefs.SetInt("CoinCount", thehealthManager.coinCount);
            PlayerPrefs.SetInt("PlayerLives", thehealthManager.currentLives);

            PlayerPrefs.SetInt(levelToUnlock, 1);

            SceneManager.LoadScene(levelToLoad);
             yield return null;
    }
}
