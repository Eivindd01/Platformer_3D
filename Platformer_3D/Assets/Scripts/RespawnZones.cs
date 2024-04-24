using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnZones : MonoBehaviour
{
    public Player playerHealth;
    public int zonesDamage = 5;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(zonesDamage);
        }

        if (!other.CompareTag("Player")) return;
                     
        if (transform.tag == "RespawnForest")
        {
            other.transform.position = new Vector3(0f, 2f, 27f);
            return;
        }

        if (transform.tag == "RespawnForestPlatforms")
        {
            other.transform.position = new Vector3(-37f, 2f, 97f);
            return;
        }

        if (transform.tag == "VillageRespawn")
        {
            other.transform.position = new Vector3(-36.7f, 2f, 220f);
            return;
        }

        if (transform.tag == "VillageRespawnPlatforms")
        {
            other.transform.position = new Vector3(-78f, 2f, 265f);
            return;
        }

        if (transform.tag == "MarketRespawn")
        {
            other.transform.position = new Vector3(-167f, 2f, 270f);
            return;
        }

        if (transform.tag == "MarketRespawnPlatforms")
        {
            other.transform.position = new Vector3(-206f, 24.3f, 239f);
            return;
        }

        if (transform.tag == "CastleRespawn")
        {
            other.transform.position = new Vector3(-187f, 24.3f, 75f);
            return;
        }

        if (transform.tag == "DungeonRespawn")
        {
            other.transform.position = new Vector3(-107f, 76.8f, 155.4f);
            return;
        }

        if (transform.tag == "WinRespawn")
        {
            PersistantData.instance.GetInfo();
            SceneManager.LoadScene("WinScene");
            return;

        }
      
    }
}
