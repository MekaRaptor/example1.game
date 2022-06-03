using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private HealthManager theHealthManager;

    public int damageToGive;
    private void Start()
    {
        theHealthManager = FindObjectOfType<HealthManager>();
    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            theHealthManager.HurtPlayer(damageToGive);
        }
    }
}
