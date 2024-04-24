using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int health, maxHealth = 3;
    [SerializeField]
    Transform killPos;

    GameObject playerGo;

    Coroutine activeCorout;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        { return; }

        if (activeCorout != null)
        {
            return;
        }

        playerGo = other.gameObject;

        activeCorout = StartCoroutine(CheckPlayerOnTopCorout());

        //Destroy(gameObject);
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        { return; }

       // playerGo = null;
    }

    IEnumerator CheckPlayerOnTopCorout()
    {
        Vector3 playerPos, pos;

        while (playerGo != null)
        {
            playerPos = playerGo.transform.position;
            playerPos.y = 0;
            pos = transform.position;
            pos.y = 0;
            float distancexz = Vector3.Distance(playerPos, pos);
            if (distancexz < 0.25)
            {
                float distancey = Mathf.Abs(playerGo.transform.position.y - killPos.position.y);
                Debug.Log(distancey);
                if (distancey < 0.05f)
                {
                    Kill();
                    //TakeDamage(health);
                    //Debug.Log(health);
                }
            }
            yield return null;
        }
        activeCorout = null;
    }

    void Kill() 
    {
        EnemiesKillCount.AddKill();
        Destroy(gameObject);
    }
}
