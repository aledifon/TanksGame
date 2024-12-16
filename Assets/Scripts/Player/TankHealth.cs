using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealth;
    [SerializeField] private Slider slider;

    GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ShellEnemy"))
        {
            // Take the 'damageShell' amount from the Component (Script) Shell from the collision.collider (GO)
            TakeDamage(collision.collider.GetComponent<Shell>().damageShell);
            // Makes disapear the shell's player
            Destroy(collision.gameObject);
        }
    }
    void TakeDamage(int amount)
    {
        currentHealth -= amount;        // Update Enemy's health
        slider.value = currentHealth;   // Update Enemy's health UI

        if (currentHealth <= 0)
            Death();            
    }
    private void Death()
    {
        // It will appear the Game Over screen
        gameManager.GameOver();
    }
}
