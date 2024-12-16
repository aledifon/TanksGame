using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Transform[] positions;
    [SerializeField] private GameObject tankEnemyPrefab;
    [SerializeField] private float time; // The number of times we call the InvokeRepeating
    
    GameManager gameManager;

    void Start()
    {
        // I can simply get the GameManager Component (Script) like this as it's contained in the same GO
        gameManager = GetComponent<GameManager>();      

        // Call the method every certain time
        InvokeRepeating("CreateTankEnemy", time, time);
    }
    
    void CreateTankEnemy()
    {
        if (gameManager.gameOver || gameManager.victory)
            return;
        else
        {
            // Place the Tanks prefabs in Random positions
            int n = Random.Range(0, positions.Length);
            Instantiate(tankEnemyPrefab, positions[n].position, positions[n].rotation);
        }
    }
}
