using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankEnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealth;
    [SerializeField] private Slider slider;

    GameManager gameManager;

    void Awake()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.collider.CompareTag("ShellPlayer"))
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
        gameManager.AddEnemyUI();
        Destroy(gameObject);        // We destroy the tank here
    }
}
