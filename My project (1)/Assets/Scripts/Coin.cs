using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private HealthManager theHealthManager;

    public int coinValue;
    private void Start()
    {
        
        theHealthManager = FindObjectOfType<HealthManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            theHealthManager.AddCoins(coinValue);

            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
