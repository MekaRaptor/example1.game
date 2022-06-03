using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Transform currentCheckpoint;
    private HealthManager playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<HealthManager>();
    }

    public void PlayerRespawn()
    {
        transform.position = currentCheckpoint.position;
        playerHealth.Respawn();
    }

}
