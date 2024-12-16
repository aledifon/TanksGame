using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject panelVictory;
    
    int numTankEnemy;                           // Num of defeated Tank enemies    
    [SerializeField] int numTanksVictory;       // Num of Tank enemies to defeat to achieve the Victory
    [SerializeField] TextMeshProUGUI textUI;    // 

    public bool gameOver,
                victory;

    void Awake()
    {
        gameOver = false;
        victory = false;
    }
    
    public void GameOver()
    {
        textUI.enabled = false;
        gameOver = true;
        panelGameOver.SetActive(true);
    }

    public void AddEnemyUI()
    {
        numTankEnemy++;                     // Increment the deated tanks enemy counter
        textUI.text = "Taks defeated: " + numTankEnemy;

        if (numTankEnemy == numTanksVictory)
        {
            // Show the victory panel
            Victory();
        }
    }

    private void Victory()
    {
        textUI.enabled = false;
        victory = true;
        panelVictory.SetActive(true);
    }
}
