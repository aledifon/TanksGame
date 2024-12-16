using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    //[SerializeField] GameObject shellPrefab;      // Ref. to the Prefab
    [SerializeField] Rigidbody shellEnemyPrefab;    // Ref. to the Prefab
    [SerializeField] Transform posShell;            // Ref. to the empty GO which represent the out bullet pos.
    [SerializeField] float timeBetweenAttacks;      // Weapon cadence
    [SerializeField] float launchForce;

    [SerializeField] float factorLaunchForce;       // Factor to control the launch force in func. of the distance
    //[SerializeField] AudioSource audioSource;     // Ref. to the audioSource component which brings the posShell object        
    
    Ray ray;                                        // The raycast itself
    RaycastHit hit;                                 // The raycast hit    
    float playerDistance;                              // The Player's distance from the Enemy
    

    private float timer;                            // Cadence shooting timer

    GameManager gameManager;

    //TankMovement tankMovement;
    void Start()
    {
        //tankMovement = GetComponent<TankMovement>();
    }

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && IPlayerDetected())
        {
            timer = 0;
            // if (RayCast Detected & Cadence shooting time elapsed & No Game Over detected)
            if (!gameManager.gameOver && !gameManager.victory)
                LaunchBullet();            
        }

        // if (RayCast Detected)
        //InvokeRepeating("Launch",timeBetweenAttacks,timeBetweenAttacks);
    }    
    void LaunchBullet()
    {
        float launchForceFinal = launchForce * playerDistance * factorLaunchForce;

        //GameObject cloneShellPrefab = Instantiate(shellPrefab,posShell.position,posShell.rotation);
        Rigidbody cloneShellPrefab = Instantiate(shellEnemyPrefab, posShell.position, posShell.rotation);
        //audioSource.Play();
                
        cloneShellPrefab.velocity = posShell.forward * launchForceFinal;
    }    

    bool IPlayerDetected()
    {
        bool isRaycastHit = false;

        // Set Raycast origin & direction
        ray.origin = transform.position;
        ray.direction = transform.forward;

        // Check if the raycast hit with something
        if (Physics.Raycast(ray, out hit))
        {
            // Check if the raycast hit with a GO with the tag 'Player'
            if (hit.collider.CompareTag("Player"))
            {
                isRaycastHit = true;
                // Gets the distance from the Enemy's tank to the Raycast hit point on the player's collider
                playerDistance = hit.distance;      
            }
        }
        // RayCast Debugging
        Debug.DrawRay(ray.origin, ray.direction, Color.red);        

        return isRaycastHit;
    }
}
