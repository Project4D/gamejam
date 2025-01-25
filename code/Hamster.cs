using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Hamster : MonoBehaviour
{
    public int health = 100;
    public GameObject deathScreen;
    public Shield shield;
    public DeathScreenController deathScreenController;

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

        if (deathScreenController != null)
        {
            StartCoroutine(LoadDeathScene());
        }
        else
        {
            Debug.LogError("DeathScreenController is not assigned!");
        }
    }

    IEnumerator LoadDeathScene()
    {
        if (deathScreenController != null)
        {
            yield return StartCoroutine(deathScreenController.FadeToBlack());
        }

        SceneManager.LoadScene("DeathScreen");

        yield return new WaitForSeconds(10);

        RestartGame();
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}