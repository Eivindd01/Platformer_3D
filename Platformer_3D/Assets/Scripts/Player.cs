using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Image HBImage;

    public int health;

    public int maxHealth = 100;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        HBImage.fillAmount = health / 100f;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
