using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class HealthManager : MonoBehaviour
{
    public CharachterController1 player1;
    public Image Heart1;
    public Image Heart2;
    public Image Heart3;

    public Sprite HeartFull;
    public Sprite HeartHalf;
    public Sprite HeartEmpty;

    public int maxhealth;
    public int healthCount;

    private bool respawning;

    public float waitToRespawn;
    public CharachterController1 thePlayer;

    public int coinCount;
    public TextMeshProUGUI coinText;

    public Text livesText;
    public int startingLives;
    public int currentLives;

    public ResetOnRespawn[] objectsToReset;

    public GameObject gameOverScreen;
    


    void Start()
    {
        
        healthCount = maxhealth;
      
 

        thePlayer = FindObjectOfType<CharachterController1>();

       

        objectsToReset = FindObjectsOfType<ResetOnRespawn>();
       

        if (PlayerPrefs.HasKey("CoinCount"))
        {
            coinCount = PlayerPrefs.GetInt("CoinCount"); 
        }
        else
        {
            coinCount = 0;
        }
        coinText.text = "X" + coinCount;

        if (PlayerPrefs.HasKey("PlayerLives"))
        {
            currentLives = PlayerPrefs.GetInt("PlayerLives");
        }
        else
        {
            currentLives = startingLives;
        }


        livesText.text = "Lives x" + currentLives;
        
    }
     void Update()
    {

        if(healthCount <= 0 && !respawning)
        {
            Respawn();
            respawning = true;
        }
       
    }
   

    public void HurtPlayer(int damageToTake)
    {
        healthCount -= damageToTake;
        UpdateHeartMeter();
    }
    public void AddHealth(int _value)
    {
        healthCount = Mathf.Clamp(healthCount + _value, 0, maxhealth);
    }
    public void Respawn()
    {
        currentLives -= 1;
        livesText.text = "Lives x" + currentLives;

        if (currentLives > 0)
        {
            StartCoroutine(RespawnCo());
          

        }
        else
        {
            thePlayer.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
        }
        AddHealth(maxhealth);
        
    }
    public IEnumerator RespawnCo()
    {
        thePlayer.gameObject.SetActive(false);

        yield return new WaitForSeconds(waitToRespawn);



        healthCount = maxhealth;
        respawning = false;
        UpdateHeartMeter();

        
        coinCount = 0;
        coinText.text = "X" + coinCount;



        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);
        for(int i=0; i < objectsToReset.Length; i++)
        {
      
            objectsToReset[i].gameObject.SetActive(true);
            objectsToReset[i].ResetObject();
        }
        
       
    }
    public void AddCoins(int coinsToadd)
    {
        coinCount += coinsToadd;
        
        coinText.text = "X" + coinCount;
        
    }
    public static void DeletePreff()
    {
        PlayerPrefs.DeleteAll();
    }
    void OnApplicationQuit()
    {
        DeletePreff();
    }

    public void UpdateHeartMeter()
    {
        switch(healthCount)
        {
            case 6: Heart1.sprite = HeartFull;
                Heart2.sprite = HeartFull;
                Heart3.sprite = HeartFull;
                return;
            case 5:
                Heart1.sprite = HeartFull;
                Heart2.sprite = HeartFull;
                Heart3.sprite = HeartHalf;
                return;
            case 4:
                Heart1.sprite = HeartFull;
                Heart2.sprite = HeartFull;
                Heart3.sprite = HeartEmpty;
                return;
            case 3:
                Heart1.sprite = HeartFull;
                Heart2.sprite = HeartHalf;
                Heart3.sprite = HeartEmpty;
                return;
            case 2:
                Heart1.sprite = HeartFull;
                Heart2.sprite = HeartEmpty;
                Heart3.sprite = HeartEmpty;
                return;
            case 1:
                Heart1.sprite = HeartHalf;
                Heart2.sprite = HeartEmpty;
                Heart3.sprite = HeartEmpty;
                return;
            case 0:
                Heart1.sprite = HeartEmpty;
                Heart2.sprite = HeartEmpty;
                Heart3.sprite = HeartEmpty;
                return;

            default:
                Heart1.sprite = HeartEmpty;
                Heart2.sprite = HeartEmpty;
                Heart3.sprite = HeartEmpty;
                return;


        }
    }

}







