using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        if (player == null)
            return;
        else
            agent.SetDestination(player.transform.position);
            
    }
}
