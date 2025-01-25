using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hamster : MonoBehaviour
{
    public int health = 100;
    public GameObject deathScreen;
    public Shield shield;

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }
    public void TakeDamage(int damage)
    {
        if (shield.IsShieldActive()) {
            return;
        }

        health -= damage;
        Debug.Log("Health is: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died");
        if (deathScreen != null)
        {
            deathScreen.SetActive(true);
        }
        
        Invoke("RestartGame", 2f);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}